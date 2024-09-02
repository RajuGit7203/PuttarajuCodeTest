using Mouri.Shared;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using Mouri.Shared;


namespace Mouri.App.Services
{
    public class CodeAnalysis : ICodeAnalysis
    {
        private readonly HttpClient _httpClient;
       
        public CodeAnalysis(HttpClient httpClient)
        {
            _httpClient = httpClient;
           
        }
        public async Task<string> GetFirstCodeAnalysis(string token)
        {
            // set jwt bearer token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);          
             var response = await _httpClient.GetAsync(Constants.ApiURLGetCodeAnalysis);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();
            return responseContent;
        }
       

        public async Task<string> PostCodeAnalyis(TypeOfObject obj, string token)
        {
            try
            {
                var objectType = new TypeOfObject
                {
                    name = obj.name
                };
                string jsonData = JsonConvert.SerializeObject(objectType);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(jsonData, Encoding.UTF8, Constants.Jsonformater);
                content.Headers.ContentType = new MediaTypeHeaderValue(Constants.Jsonformater);               
                var response = await _httpClient.PostAsync(Constants.apiURLPostCodeAnalyis, content);
                var responseContent = response.Content.ReadAsStringAsync().Result;
                response.EnsureSuccessStatusCode();
                return responseContent;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> GenerateToken(User user)
        {           
            string jsonData = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonData, Encoding.UTF8, Constants.Jsonformater);
            content.Headers.ContentType = new MediaTypeHeaderValue(Constants.Jsonformater);
            var token = await _httpClient.PostAsync(Constants.ApiToken, content);
            var tokenValue = token.Content.ReadAsStringAsync().Result;
            return tokenValue;
        }

    }
}
