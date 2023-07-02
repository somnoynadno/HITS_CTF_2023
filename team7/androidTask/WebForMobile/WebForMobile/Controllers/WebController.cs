using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebForMobile.Controllers
{
    [Route("api/web")]
    [ApiController]
    public class WebController : ControllerBase
    {
        private readonly FlagDto _flag;

        public WebController(IOptions<FlagDto> configuration)
        {
            _flag = configuration.Value;
        }

        [HttpPost]
        public ActionResult<TokenDto> GetToken(SignInDto signIn)
        {
            var nowTime = DateTime.Now;
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, signIn.Email) };

            var jwt = new JwtSecurityToken(
                issuer: JwtConfigs.Issuer,
                audience: JwtConfigs.Audience,
                notBefore: nowTime,
                claims: claims,
                expires: nowTime.AddMinutes(JwtConfigs.Lifetime),
                signingCredentials: new SigningCredentials(JwtConfigs.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new TokenDto { Token = accessToken });
        }

        [HttpGet("flag")]
        [Authorize]
        public ActionResult<FlagDto> GetFlag()
        {
            return Ok(_flag.Flag);
        }
    }
}
