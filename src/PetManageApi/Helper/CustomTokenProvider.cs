using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetManageApi.Helper
{
    public class CustomTokenProvider
    {
        
        public static string CreateToken(string displayName, string userId)
        {
            string key = "78319B5F-6868-4B28-B08C-98564A293F38"; //Secret key which will be used later during validation    
            var issuer = "http://localhost:7001";  //normally this will be your site URL    

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            permClaims.Add(new Claim("aspid", userId));
            permClaims.Add(new Claim("displayname", displayName));
            

            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt_token;
        }
    }
}
