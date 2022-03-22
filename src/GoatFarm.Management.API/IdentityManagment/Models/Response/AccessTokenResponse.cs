namespace GoatFarm.Management.API.IdentityManagement.Models.Response
{
    public class AccessTokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
    }
}
