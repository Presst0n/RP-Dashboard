namespace ResPublicaDashboard.Models
{
    public interface ILoggedInUserModel
    {
        string BattleTag { get; set; }
        string Token { get; set; }

        void LogOffUser();
    }
}