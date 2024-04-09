using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Infrastructure.Services;

public class CategoryService(IHttpClientFactory clientFactory, IConfiguration configuration)
{
    private readonly IHttpClientFactory _clientFactory = clientFactory;
    private readonly IConfiguration _configuration = configuration;

    public async Task<IEnumerable<Category>> GetCategoriesAsync(string accessToken)
    {
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var apiKey = _configuration["ApiKey:Secret"];
        var response = await client.GetAsync($"https://localhost:7226/api/categories?key={apiKey}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(content);
            return categories ?? new List<Category>();
        }
        return new List<Category>();
    }
}
