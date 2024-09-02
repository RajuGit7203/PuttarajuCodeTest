
using Mouri.Shared;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Mouri.App.Services
{
    public class PatientService : IPatient
    {
        private readonly HttpClient _httpClient;       
        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           
        }
     
        public async Task<Patient> GetPatientInfo(string id, string token)
        {
            try
            {
                
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<Patient>($"api/Patient/GetPatient/{id}");
                return response;
            } catch (Exception ex)
            {
                return new Patient();
            }
        }
        public async Task<string> GenerateToken()
        {
            var user = new User
            {
                UserName = "Admin",
                PassWord = "PassWord"
            };
            string jsonData = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonData, Encoding.UTF8, Constants.Jsonformater);
            content.Headers.ContentType = new MediaTypeHeaderValue(Constants.Jsonformater);
            var token = await _httpClient.PostAsync(Constants.ApiToken, content);
            var tokenValue = token.Content.ReadAsStringAsync().Result;
            return tokenValue;
        }

        
    }
}
