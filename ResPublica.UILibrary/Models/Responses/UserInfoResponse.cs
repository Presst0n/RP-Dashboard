using Newtonsoft.Json;

namespace ResPublica.UILibrary.Models.Responses
{
    public class UserInfoResponse
    {
        [JsonProperty("BattleTag")]
        public string BattleTag { get; set; }
    }
}
