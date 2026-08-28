using Employee_Management.Services.Interface;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;

namespace Employee_Management.Services.Repository
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string username)
        {
            // Claim is a piece of information about the authenticated user stored inside the JWT
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username), //Claims user ki information hoti hai jo token ke andar store hoti hai
                    //new Claim(ClaimTypes.Role,"Admin") // multiple claim 
            };

            // Key
            //appsettings.json se Secret Key read kar rahe hain.
            //String ko bytes me convert kar rahe hain.
            //Ye key token ko sign aur validate karne ke liye use hoti hai


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); // Secret Key is used to digitally sign the JWT so that it cannot be tampered with


            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], //Token kis application ne issue kiya hai
                audience: _configuration["Jwt:Audience"], //Token kis client/application ke liye generate hua hai
                claims: claims, //User ki information token ke andar add kar rahe hain
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])), //Token kitni der tak valid rahega
                signingCredentials: credentials //Jo credentials upar banaye the unse token digitally sign hoga.
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
    

