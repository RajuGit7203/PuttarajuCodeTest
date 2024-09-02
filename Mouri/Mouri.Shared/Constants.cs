using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouri.Shared
{
    public static class  Constants
    {
        public const  string apiURLPostCodeAnalyis = "api/API2/PostCodeAnalyis";
        public const string Jsonformater = "application/json";
        public const string ApiURLGetCodeAnalysis = "api/API2/GetCodeAnalyis";
        public const string ApiURLGetPatient= "api/Patient/GetPatient/";
        public const string ApiToken = "api/User/token";
        public const string InvalidUsers = "UserName or Password is incorrect";
        public const string InvalidCodeAnalysis = "Invalid Answer for codeAnalysis: ";
        public const string InvalidCodeAnalyisPart = "  Explaniation is for codeAnalysis is not emit bow-wow because " +
                "the Dog class does not override the speak method from the Animal class ";
        public const string PostAsyncMessage = " :This is an additional functionlaity to achive two API's triggered Asynchronously same instance "
                + " but to dispaly the Post API on blazor page requried hit on PostAPI button";
        public const string JwtKey = "Jwt:Key";
        public const string Issuer = "Jwt:Issuer";
        public const string Audience = "Jwt:Audience";
    }
}
