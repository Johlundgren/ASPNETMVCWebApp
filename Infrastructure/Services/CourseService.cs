using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public class CourseService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        private readonly IHttpClientFactory _clientFactory = clientFactory;
        private readonly IConfiguration _configuration = configuration;

        public async Task<IEnumerable<Course>> GetCoursesAsync(string accessToken, string category = "", string searchQuery = "")
        {

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var apiKey = _configuration["ApiKey:Secret"];
            var response = await client.GetAsync($"https://localhost:7226/api/courses?key={apiKey}&category={category}&searchQuery={searchQuery}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CourseResult>(content);
                if (result != null && result.Succeeded)
                {
                    return result.Courses ?? new List<Course>();
                }
            }
            return new List<Course>();
        }
    }
}

//using Infrastructure.Models;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;

//namespace Infrastructure.Services;

//    public class CourseService(HttpClient http, IConfiguration configuration)
//    {
//        private readonly HttpClient _http = http;
//        private readonly IConfiguration _configuration = configuration;


//        public async Task<IEnumerable<Course>> GetCoursesAsync()
//        {
//            var response = await _http.GetAsync($"https://localhost:7226/api/courses?key={_configuration["ApiKey:Secret"]}");
//            if (response.IsSuccessStatusCode)
//            {
//                var result = JsonConvert.DeserializeObject<CourseResult>(await response.Content.ReadAsStringAsync());
//                if (result != null && result.Succeeded)
//                {
//                return result.Courses ??= null!;
//                }
//            }
//            return null!;
//        }
//    }

