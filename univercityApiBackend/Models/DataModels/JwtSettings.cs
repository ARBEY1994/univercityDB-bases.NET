namespace univercityApiBackend.Models.DataModels
{
    public class JwtSettings
    {

        public bool ValidateIsUserSigniKey { get; set; }
        public string IssuerSigninKey { get; set; } = string.Empty;
        public bool ValidateISsuer { get; set; } = true;
        public string? ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set;}

        public bool RequireExpirationTime { get; set; }
        public bool ValidateLifeTime { get; set; } = true;

    }
}
