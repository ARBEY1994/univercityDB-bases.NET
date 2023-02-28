using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using univercityApiBackend.Models.DataModels;

namespace univercityApiBackend
{
    public static class AddJwtTokenServicesExtensions
    {
        public static void AddJwtTokenServices(this IServiceCollection Services,IConfiguration Configuration)
        {
            //add jwt settings
            var bindJwtSettings = new JwtSettings();
            Configuration.Bind("JsonWebTOkensKeys", bindJwtSettings);
            //Add singleton of jwt settings
            Services.AddSingleton(bindJwtSettings);

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSettings.ValidateIsUserSigniKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigninKey)),
                    ValidateIssuer = bindJwtSettings.ValidateISsuer,
                    ValidIssuer = bindJwtSettings.ValidIssuer,
                    ValidateAudience = bindJwtSettings.ValidateAudience,
                    ValidAudience=bindJwtSettings.ValidAudience,
                    RequireExpirationTime= bindJwtSettings.RequireExpirationTime,
                    ValidateLifetime= bindJwtSettings.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromDays(1)

                };

            });
        }
    }
}
  