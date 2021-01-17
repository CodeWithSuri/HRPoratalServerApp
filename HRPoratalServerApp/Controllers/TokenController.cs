using HRPoratalServerApp.RepositoryPattren;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPoratalServerApp.Models;

//new namespaces for JWT
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;



namespace HRPoratalServerApp.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {


        public IConfiguration _configuration;

        private IRepositoryWrapper _repositoryWrapper;

        public TokenController(IRepositoryWrapper repositoryWrapper, IConfiguration configuration)
        {
            _repositoryWrapper = repositoryWrapper;
            _configuration = configuration;
        }

        User acctualData = new User();

        [HttpPost]
        public async Task<IActionResult> ValidateUser(User userdet)
        {
            bool response = false;

            if (userdet != null)
            {

                if (userdet.userName != null && userdet.password != null)
                {

                    response = acctualData.ValidateUser(userdet.userName, userdet.password);

                }


                if (response)
                {

                    //creating cliam details based on user information 

                    var claims = new[]
                    {

                    new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),

                    new Claim("Id",acctualData.EmployeeId),
                    new Claim("username",acctualData.userName),
                    new Claim("pwd",acctualData.password)

                };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));


                    var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                        claims, expires: DateTime.Now.AddDays(1), signingCredentials: signin);




                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));


                }
                else
                {



                    return BadRequest("Invalid username or password !");
                }
                

            }

            return BadRequest();

        }
    
    
    
    //
    }
}


