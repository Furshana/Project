using GoToMeetingApp.Handler;
using GoToMeetingApp.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GoToMeetingApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GtmLoginDetailsController : ControllerBase
    {
        private readonly Gotomeeting_dbContext context;
        private readonly JWTSettings _jwtSettings;
        public GtmLoginDetailsController(Gotomeeting_dbContext _DbContext,IOptions<JWTSettings> options)
        {
            context = _DbContext;
            _jwtSettings = options.Value;
            
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] GtmLoginDetails gtmLoginDetails)
        {
            var _gtmLoginDetails = context.GtmMeetingRoomDetails.FirstOrDefault(o => o.UserId == gtmLoginDetails.UserId && o.Password == gtmLoginDetails.LoginPassword);
            if (_gtmLoginDetails == null)

                return Unauthorized();
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
              Subject = new ClaimsIdentity(new Claim[]
              {
                 new Claim(ClaimTypes.Name, gtmLoginDetails.Name)
              }),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            return Ok(finaltoken); 
        }
    }
}     
        
