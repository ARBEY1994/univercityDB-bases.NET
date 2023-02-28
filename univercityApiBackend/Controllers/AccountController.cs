using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using univercityApiBackend.DataAccess;
using univercityApiBackend.Helpers;
using univercityApiBackend.Models.DataModels;

namespace univercityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDbContext _context;
        private readonly JwtSettings _jwtSettings;
        public AccountController(UniversityDbContext context,JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }
        //TODO: cambiar por usuarios reales
        private IEnumerable<User> Logins = new List<User>()
        {
             new User()
             {
                 Id=1,
                 Email= "arbey221@gmail.com",
                 Name= "admin",
                 Password="admin"

             },
               new User()
             {
                 Id=2,
                 Email= "hei221@gmail.com",
                 Name= "User1",
                 Password="admins"

             }
        };
        [HttpPost]
        public async IActionResult GetToken (UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();

                var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName=user.Name,
                        EmailId=user.Email,
                        Id=user.Id,
                        GuidId=Guid.NewGuid(),
                    },_jwtSettings);
                }
                else
                {
                    return BadRequest("wrong passsword");
                }
                return Ok(Token);

            }catch(Exception ex)
            {
                throw new Exception("Get token error", ex);
            }
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles= "Administrator")]
        public IActionResult GetUserList() 
        {
            return Ok(Logins);
        }

    }
}
