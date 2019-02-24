namespace APIBrumadinho
{
    class EscavadorEndPoints
    {
        internal const string BASEURL = "https://api.escavador.com";

        internal const string APIVERSION = "/api/v1";

        internal const string CONCAT = BASEURL + APIVERSION;

        internal const string TOKEN = CONCAT + "/request-token";

        internal const string CREDITS = CONCAT + "/quantidade-creditos";

        internal const string SEARCH = CONCAT + "/busca";

        internal const string SEARCHPEOPLE = CONCAT + "/pessoas/{0}";

        internal const string INSTITUTION = CONCAT + "/instituicoes/{0}";
#pragma warning disable SA1507 // Code should not contain multiple blank lines in a row


        internal static string UserName { get; set; } = string.Empty;
#pragma warning restore SA1507 // Code should not contain multiple blank lines in a row

        internal static string Password { get; set; } = string.Empty;

        internal static string AccessToken { get; set; } = string.Empty;

        internal static string RefreshToken { get; set; } = string.Empty;
    }
}
