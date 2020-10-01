//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var framework = Argument("framework", "netcoreapp3.1");
var outPackDir = Argument("outpackdir", "./artifacts/");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

const string PROJECT_NAME = "School";
const string PROJECT_SOLUTION = PROJECT_NAME + ".sln";
const string TEST_PROJECT_DIRECTORY = "./tests/" + PROJECT_NAME;
const string TEST_PROJECT_DIRECTORY_UNIT = TEST_PROJECT_DIRECTORY + ".Tests.Unit";
const string TEST_PROJECT_DIRECTORY_INTEGRATION = TEST_PROJECT_DIRECTORY + ".Tests.Integration";
const string TEST_PROJECT_DIRECTORY_API = TEST_PROJECT_DIRECTORY + ".Tests.Api";
const string PROJECT_DIRECTORY_API = "./src/" + PROJECT_NAME + ".Api";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{	    
     DotNetCoreClean(PROJECT_SOLUTION);   
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{       
	DotNetCoreRestore(PROJECT_SOLUTION);	
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{    
	 var projectsBuildSettings = new DotNetCoreBuildSettings
     {     
         Configuration = configuration		 
     };
	 DotNetCoreBuild(PROJECT_SOLUTION, projectsBuildSettings);
});

Task("Tests")
    .IsDependentOn("Build")
    .Does(() =>
{    
	var testSettings = new DotNetCoreTestSettings()
	{
		Configuration = configuration,
		NoBuild = true,
		NoRestore = true,
		Verbosity = DotNetCoreVerbosity.Normal
	};
	DotNetCoreTest(TEST_PROJECT_DIRECTORY_UNIT, testSettings);
	DotNetCoreTest(TEST_PROJECT_DIRECTORY_INTEGRATION, testSettings);
	DotNetCoreTest(TEST_PROJECT_DIRECTORY_API, testSettings);
});

Task("Run-API")		
	.IsDependentOn("Tests")	
	.Does(() =>
	{				
		var runSettings = new DotNetCoreRunSettings
		{         
			Configuration = configuration
		};		
		DotNetCoreRun(PROJECT_DIRECTORY_API, "--args", runSettings);				
	});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-API");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);