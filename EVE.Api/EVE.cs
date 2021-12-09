using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EVE.Api
{
    public class EVE
    {
        private JsonSerializerOptions JsonOptions { get; init; }
        private HttpClient Client { get; init; }

        public EVE()
        {
            // Create object of JsonSerializer to ignore Upper Case
            this.JsonOptions = new JsonSerializerOptions();
            this.JsonOptions.PropertyNameCaseInsensitive = true;
            this.JsonOptions.WriteIndented = true;

            string cheatToken = null;
            string clientId = ReadLocalSettings("ClientID");
            string secretKey = ReadLocalSettings("SecretKey");

            this.Client = new HttpClient() // This will be entry for http calls. Will need to create a wrapper at some point
            {
                BaseAddress = new Uri("https://esi.evetech.net/latest/")
            };

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", cheatToken);
        }

        public async Task<CharacterCore> CharacterAsync(string characterId)
        {
            var url = $"characters/{characterId}/?datasource=tranquility";

            return await GetHttpResponseAsync<CharacterCore>(url);
        }

        // Move function to static class called "Tools" etc.
        public string ReadLocalSettings(string key)
        {
            using var sr = new StreamReader("local.settings.json");
            // Read the stream as a string, and write the string to the console.
            string filecontent = sr.ReadToEnd();
            var res = JsonSerializer.Deserialize<Dictionary<string, object>>(filecontent);

            return res[key].ToString();
        }

        public async Task<List<Mail>> GetCharacterMail(string characterId) 
        {

            var url = $"characters/{characterId}/mail/?datasource=tranquility";
            var mailResp = await GetHttpResponseAsync<List<Mail>>(url);

            return mailResp;
        }

        public async Task<T> GetHttpResponseAsync<T>(string url)
        {
            HttpResponseMessage res = await Client.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"No HTTP Response retrieved with error {res.StatusCode}");
            }
            var contentAsStream = await res.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(contentAsStream, JsonOptions);
        }
        public async Task<T> PostHttp<T>(string url)
        {
            HttpResponseMessage res = await Client.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"No HTTP Response retrieved with error {res.StatusCode}");
            }
            var contentAsStream = await res.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<T>(contentAsStream, JsonOptions);
        }

    }
}
