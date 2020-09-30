using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;

namespace School.Domain.Shared.Extensions
{
    public static class JsonSerializationExtension
    {
        public static StringContent ToJsonContent<T>(this T objeto) =>
            new StringContent(JsonConvert.SerializeObject(objeto, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }), Encoding.UTF8, "application/json");
    }

}