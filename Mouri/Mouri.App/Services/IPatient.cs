using Mouri.Shared;

namespace Mouri.App.Services
{
    public interface IPatient
    {
        Task<Patient> GetPatientInfo(string id, string token);
        Task<string> GenerateToken();
    }
}
