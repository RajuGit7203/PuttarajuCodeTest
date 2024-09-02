using Mouri.Shared;

namespace Mouri.App.Services
{
    public interface ICodeAnalysis
    {
        Task<string> GetFirstCodeAnalysis(string token);
        Task<string> PostCodeAnalyis(TypeOfObject type, string token);
        Task<string> GenerateToken(User user);
    }
}
