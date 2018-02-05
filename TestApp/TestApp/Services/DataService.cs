using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestApp.Services
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        public async Task<T> GetInfoAsync<T>(string requestURI)
        {
            client.BaseAddress = new Uri(requestURI);
            var responce = await client.GetAsync(requestURI);
            var content = await responce.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }

        public async Task<bool> PingResource(string requestURI)
        {
            client.BaseAddress = new Uri(requestURI);
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(requestURI);
            request.Method = HttpMethod.Head;
            HttpResponseMessage response = await client.SendAsync(request);
            return (response.IsSuccessStatusCode) ? true : false;
        }

        public async Task<Dictionary<string, T>> GetContentInfoAsync<T>(string requestURI)
        {
            client.BaseAddress = new Uri(requestURI);
            var responce = await client.GetAsync(requestURI);
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();

            JObject obj = JObject.Parse(content);
            var subJSONString = obj.SelectToken(@"$.content");

            Dictionary<string, T> dictionary = JsonConvert.DeserializeObject<Dictionary<string, T>>(subJSONString.ToString());
           
            return dictionary;
        }
    }
}
