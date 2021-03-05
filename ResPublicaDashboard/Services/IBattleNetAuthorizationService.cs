using System.Threading.Tasks;

namespace ResPublicaDashboard.Services
{
    public interface IBattleNetAuthorizationService
    {
        Task<bool> LogInWithBattleNetAsync();
    }
}