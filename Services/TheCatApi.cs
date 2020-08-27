using BlazorCats.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorCats.Services
{
    public class TheCatApi
    {
        private const string _apiKey = "37b328f5-bcd9-4c0b-93e0-6d7b04e7d45d";
        private readonly HttpClient _client;

        private const string _apiHost = "https://api.thecatapi.com";
        private const string _searchEndpoint = "images/search";
        private const string _breedEndpoint = "breeds";

        public TheCatApi(HttpClient client)
        {
            _client = client;
            PopulateHeaders();
        }

        public async Task<ApiResult<IEnumerable<CatImage>>> Search(SearchFilters filters)
        {
            var url = $"{_apiHost}/{_searchEndpoint}{filters}";

            var result = await _client.GetAsync(url);

            if (!result.IsSuccessStatusCode)
            {
                return new ApiResult<IEnumerable<CatImage>>(result.StatusCode, null);
            }

            var images = JsonSerializer.Deserialize<List<CatImage>>(await result.Content.ReadAsStringAsync());

            return new ApiResult<IEnumerable<CatImage>>(HttpStatusCode.OK, images);
        }

        public async Task<ApiResult<IEnumerable<Breed>>> SearchByBreed(string id, SearchFilters filters)
        {
            var url = $"{_apiHost}/v1/{_searchEndpoint}";

            if (filters.AreSet())
            {
                url += $"{filters}&breed_ids={id}";
            }

            var result = await _client.GetAsync(url);

            if (!result.IsSuccessStatusCode)
            {
                return new ApiResult<IEnumerable<Breed>>(result.StatusCode, null);
            }

            var json = await result.Content.ReadAsStringAsync();
            var breeds = JsonSerializer.Deserialize<List<Breed>>(json);

            return new ApiResult<IEnumerable<Breed>>(HttpStatusCode.OK, breeds);
        }

        public async Task<ApiResult<IEnumerable<Breed>>> GetAllBreed()
        {
            var url = $"{_apiHost}/v1/{_breedEndpoint}";

            var result = await _client.GetAsync(url);

            if (!result.IsSuccessStatusCode)
            {
                return new ApiResult<IEnumerable<Breed>>(result.StatusCode, new List<Breed>());
            }

            var json = await result.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var breeds = JsonSerializer.Deserialize<List<Breed>>(json, options);
            return new ApiResult<IEnumerable<Breed>>(HttpStatusCode.OK, breeds);
        }

        private void PopulateHeaders()
        {
            _client.DefaultRequestHeaders.Add("x-api-key", _apiKey);
        }
    }
}
