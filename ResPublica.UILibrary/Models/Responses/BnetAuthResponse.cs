using Newtonsoft.Json;

namespace ResPublica.UILibrary.Models.Responses
{
    public class BnetAuthResponse
    {
        [JsonProperty("Access_Token")]
        public string Access_Token { get; set; }
    }
}
