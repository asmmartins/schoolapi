﻿using Microsoft.Extensions.DependencyInjection;
using School.Application.UseCases.CreateGroup;
using School.Application.UseCases.CreatePublicSchool;
using School.Application.UseCases.GetGroup;
using School.Application.UseCases.GetGroups;
using School.Application.UseCases.GetPublicSchool;
using School.Application.UseCases.GetPublicSchools;
using School.UseCases.CreateGroup;
using School.UseCases.CreatePublicSchool;
using School.UseCases.GetGroup;
using School.UseCases.GetGroups;
using School.UseCases.GetPublicSchool;
using School.UseCases.GetPublicSchools;

namespace School.Infra.Ioc
{
    internal static class UseCasesDependecyInjection
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreatePublicSchoolUseCase, CreatePublicSchoolUseCase>();
            services.AddTransient<ICreateGroupUseCase, CreateGroupUseCase>();
            services.AddTransient<IGetPublicSchoolUseCase, GetPublicSchoolUseCase>();
            services.AddTransient<IGetGroupsUseCase, GetGroupsUseCase>();
            services.AddTransient<IGetGroupUseCase, GetGroupUseCase>();
            services.AddTransient<IGetPublicSchoolsUseCase, GetPublicSchoolsUseCase>();
        }
    }
}
