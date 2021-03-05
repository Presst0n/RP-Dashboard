using System.Threading.Tasks;

namespace ResPublica.UILibrary.Api
{
    public interface IBattleNetApiHelper
    {
        Task<bool> AuthorizeAsync();
        Task<string> GetBattleTagByTokenAsync(string token);
        Task<string> GetAccessTokenAsync();
        Task<bool> ValidateTokenAsync(string token);
    }
}