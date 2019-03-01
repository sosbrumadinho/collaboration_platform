namespace APIBrumadinho
{
    internal class LinkedinEndPoints
    {
        internal const string BASEURL = "https://api.linkedin.com/v2";

        internal const string AUTH = BASEURL + "/accessToken";

        internal const string TOKEN = "https://www.linkedin.com/oauth/v2/accessToken";

        // Mudar essa url pra original dentro do devops.
        internal const string REDIRECTURL = "https://www.teste.com/teste";

        internal static string ClientId { get; set; } = string.Empty;

        internal static string ClientSecret { get; set; } = string.Empty;

        internal static string AuthCode { get; set; } = string.Empty;

        internal static string AccessToken { get; set; } = string.Empty;

        internal static string ExpiresIn { get; set; } = string.Empty;
    }
}
