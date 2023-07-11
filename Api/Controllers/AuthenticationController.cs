using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using JWT.Algorithms;
using JWT.Builder;

namespace Api.Controllers
{
    [ApiController, Route("/api/authentication")]
    public class AuthenticationController : Controller
    {
     
        private readonly UserManager<UserEntity> _manager;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger _logger;
        public RoleManager<UserRole> rolemanager;
        public AuthenticationController(UserManager<UserEntity> manager, RoleManager<UserRole> roleMgr, ILogger<AuthenticationController> logger, IConfiguration configuration, JwtSettings
       jwtSettings)
        {
            _manager = manager;
            _logger = logger;
            _jwtSettings = jwtSettings;
            rolemanager = roleMgr;
        }

        [HttpPost("register")]
        public async void Register([FromBody] LoginUserDto user)
        {


            if (!ModelState.IsValid)
            {

                return;
            }
            UserEntity userEntity = new UserEntity();
            userEntity.UserName = user.LoginName;


            //var newrole = new UserRole();
            //newrole.Name = "Admin";
            // rolemanager.CreateAsync(newrole);
            await _manager.CreateAsync(userEntity, user.Password);
            await _manager.AddToRoleAsync(userEntity, "User");
            //await _manager.AddToRoleAsync(userEntity, "Admin");
            return;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginUserDto user)
        {
            await Console.Out.WriteLineAsync(   user.LoginName);
            if (!ModelState.IsValid)
            {
                
                return Unauthorized();
            }
            var logged = await _manager.FindByNameAsync(user.LoginName);
            if (await _manager.CheckPasswordAsync(logged, user.Password))
            {
                return Ok(new { Token = CreateToken(logged) });
            }
            return Unauthorized();
        }
        private async void GetUserRoles(UserEntity user)
        {
            role = (List<string>)await _manager.GetRolesAsync(user).ConfigureAwait(false);
            foreach (var role in role)
            {
                await Console.Out.WriteLineAsync(   role.ToLower());
            }

            return;

        }
        private List<string> role { get; set; }
        private string CreateToken(UserEntity user)
        {

            GetUserRoles(user);

            Console.WriteLine(role);
            JwtBuilder jwtb = new JwtBuilder()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
            .AddClaim(JwtRegisteredClaimNames.Name, user.UserName)
            .AddClaim(JwtRegisteredClaimNames.Gender, "male")
            .AddClaim(JwtRegisteredClaimNames.Email, user.Email)
            .AddClaim(JwtRegisteredClaimNames.Exp,
           DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds())
            .AddClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid())
            .Audience(_jwtSettings.Audience)
            .Issuer(_jwtSettings.Issuer);
            //.Encode();

            jwtb.AddClaim(ClaimTypes.Role, role);


            
            return jwtb.Encode();
           
        }
    }
}
//{
//    "loginName": "user",
//  "password": "1Userpassword!"
//}\
//{
//    "loginName": "admin",
//  "password": "1Adminpassword!"
//}