using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCats.Services
{
    public class HttpCat
    {
        private readonly HttpClient client;

        public HttpCat(HttpClient client)
        {
            this.client = client;
        }

        public async Task<String> Get(HttpStatusCode code)
        {
            var result = await client.GetAsync($"https://http.cat/{code}");

            var bytes = await result.Content.ReadAsByteArrayAsync();

            return Convert.ToBase64String(bytes);
        }
    }
}
