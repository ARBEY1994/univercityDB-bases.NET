using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using univercityApiBackend.Models.DataModels;

namespace univercityApiBackend.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd YYYY HH:mm:ss  tt"))

            };
            if(userAccounts.UserName == "admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "administrador"));
            }else if (userAccounts.UserName=="User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }
            return claims;

        }
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);

        }
        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                //obtain SECRET KEY
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigninKey);
                Guid Id;
                // expired 1 day
                DateTime expiredTime = DateTime.UtcNow.AddDays(1);

                //Validity of our  token 
                userToken.Validity = expiredTime.TimeOfDay;

                //Generate jwt
                var jwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expiredTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256));

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;

                return userToken;

                    
            }
            catch(Exception exception)
            {
                throw new Exception("Error generate en JWT", exception);
            }

        }

        internal static UserTokens GetTokenKey(UserTokens userTokens)
        {
            throw new NotImplementedException();
        }
    }
}
