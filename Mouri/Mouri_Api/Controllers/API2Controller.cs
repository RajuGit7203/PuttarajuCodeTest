using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mouri.Shared;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Mouri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class API2Controller : ControllerBase
    {
        // added Authorization filter 
        [HttpGet]
        [Route("GetCodeAnalyis")]
        [Authorize]
        public async Task<string> GetCodeAnalyis()
        {          
            var codeAnalysisResult = new Analysis();
            Animal d = new Dog();
            await Task.Delay(1000);
            codeAnalysisResult.Message = Constants.InvalidCodeAnalysis + d.speak(0)?.ToUpper() + Constants.InvalidCodeAnalyisPart;
            return codeAnalysisResult.Message;
        }
        // added Authorization filter 
        [HttpPost]
        [Route("PostCodeAnalyis")]
        [Authorize]
        public async Task<string> PostCodeAnalyis(TypeOfObject type)
        {
            var codeAnalysisResult = new Analysis();
            var animals = new Animals(type.name);
            string result = animals.ScanAnimalSpeakType();
            await Task.Delay(1000);
            return codeAnalysisResult.SecondMessage = result.ToUpper() + Constants.PostAsyncMessage;
        }
    }
}
