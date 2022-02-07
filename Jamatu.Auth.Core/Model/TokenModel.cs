namespace Jamatu.Auth.Core.Model
{
    public class TokenModel
	{
		public TokenModel(string token, int expires)
		{
			Token = token;
			Expires = expires;
		}
		public string Token { get; set; }
		public int Expires { get; set; }
	}
}
