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
        private JsonSerializerOptions jsonOptions { get; init; }
        private HttpClient Client { get; init; }

        public EVE(JsonSerializerOptions jsonOptions)
        : base()
        {
            this.jsonOptions = jsonOptions;
        }

        public EVE()
        {
            // Create object of JsonSerializer to ignore Upper Case
            jsonOptions = new JsonSerializerOptions();
            jsonOptions.PropertyNameCaseInsensitive = true;
            jsonOptions.WriteIndented = true;

            string cheatToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkpXVC1TaWduYXR1cmUtS2V5IiwidHlwIjoiSldUIn0.eyJzY3AiOiJlc2ktbWFpbC5yZWFkX21haWwudjEiLCJqdGkiOiI2OTA2MTczNS02Mjc2LTRjZTgtOTFhMi0xNzk5YjE5MmIxNmIiLCJraWQiOiJKV1QtU2lnbmF0dXJlLUtleSIsInN1YiI6IkNIQVJBQ1RFUjpFVkU6MjExNDUxMzMwMSIsImF6cCI6IjY4MzA4NGFiNWY4ODQ4ZDRiMTg3NDYyYWMzYjk3Njc3IiwidGVuYW50IjoidHJhbnF1aWxpdHkiLCJ0aWVyIjoibGl2ZSIsInJlZ2lvbiI6IndvcmxkIiwibmFtZSI6IlBqb3RyIE1ha2FuZW4iLCJvd25lciI6Ii9oUnBsem1aNGJJQTdwcndDWWIwWGR1VzhIST0iLCJleHAiOjE2MzcwMDY2MjMsImlhdCI6MTYzNzAwNTQyMywiaXNzIjoibG9naW4uZXZlb25saW5lLmNvbSJ9.HSCMInMHVj4ZNshwkBR7nC4_FbqdLIFPW4S3HW5Td-qN6i9zOvRbemIoGdzrNyGLylETs5pT9B-jk_cUy0fdZgmJ37A6MQxTQ-2LS9IybCqw0PO90zeE8Gtm-BLrMm0T6brZHF99hEpcLFGSwxbw_yJj-8C0caaNLjQ-FuiWhbvNnVqslARla7rEOq69vJQJSunuj128H5UEjlL37THP8WWP_PYzQgseMUZqrfdFMYW6lqPt9CnJty-51fBIwd7dd3dOXxnBl4VI5ohlNVwmzRIGIfiQLYdZb3czHCZjxIhyh8zEN4olT63WycklctNxd2pgeYCzNsPR4UIQscigCA";

            Client = new HttpClient() // This will be entry for http calls. Will need to create a wrapper at some point
            {
                BaseAddress = new Uri("https://esi.evetech.net/latest/")
            };

            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", cheatToken);
        }

        public async Task<CharacterCore> CharacterAsync(string characterId)
        {
            string clientId = ReadLocalSettings("ClientID");
            string secretKey = ReadLocalSettings("SecretKey");

            var type = "mail";

            

            HttpResponseMessage res = await Client.GetAsync($"characters/{characterId}/?datasource=tranquility");
            HttpResponseMessage resMail = await Client.GetAsync($"characters/{characterId}/{type}/?datasource=tranquility");

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"No HTTP Response retrieved with error {res.StatusCode}");
            }

            var contentAsStream = await res.Content.ReadAsStreamAsync();


            // Get the stream from HttpRespone to deserialize as Object CharacterCore

            return await JsonSerializer.DeserializeAsync<CharacterCore>(contentAsStream, jsonOptions);

        }
        public string ReadLocalSettings(string key)
        {

            using var sr = new StreamReader("local.settings.json");

            // Read the stream as a string, and write the string to the console.
            string filecontent = sr.ReadToEnd();

            var res = JsonSerializer.Deserialize<Dictionary<string, object>>(filecontent);

            return res[key].ToString();
        }
    }
}
