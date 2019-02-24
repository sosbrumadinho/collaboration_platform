namespace APIBrumadinho
{
    internal class LinkedinEndPoints
    {
        internal const string BASEURL = "https://api.linkedin.com/v2";

        internal const string AUTH = BASEURL + "/accessToken";

        internal const string TOKEN = "https://www.linkedin.com/oauth/v2/accessToken";

        internal static string ClientId { get; set; } = string.Empty;

        internal static string ClientSecret { get; set; } = string.Empty;
    }
}
