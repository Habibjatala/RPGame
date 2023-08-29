using FirstTut.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FirstTut.Data
{
    public class Tester
    {
        /////////////////////////////////////////////////
        //      ///
        //      private string CreateToken(User user)
        //      {
        //          var claims = new List<Claim>
        //          {
        //      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //      new Claim(ClaimTypes.Name, user.Username)
        //  };

        //          var appSettingToken = _configuration.GetSection("AppSettings:Token").Value;

        //          if (string.IsNullOrEmpty(appSettingToken))
        //          {
        //              throw new Exception("Token is Null or Empty.");
        //          }

        //          byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(appSettingToken);
        //          byte[] validKeyBytes = new byte[64]; // 512 bits = 64 bytes

        //          // Ensure that the key is 512 bits by either truncating or padding it.
        //          if (keyBytes.Length >= validKeyBytes.Length)
        //          {
        //              Array.Copy(keyBytes, validKeyBytes, validKeyBytes.Length);
        //          }
        //          else
        //          {
        //              Array.Copy(keyBytes, validKeyBytes, keyBytes.Length);
        //          }

        //          SymmetricSecurityKey key = new SymmetricSecurityKey(validKeyBytes);

        //          SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //          var tokenDescriptor = new SecurityTokenDescriptor
        //          {
        //              Subject = new ClaimsIdentity(claims),
        //              Expires = DateTime.Now.AddDays(1),
        //              SigningCredentials = creds
        //          };

        //          JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //          SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        //          return tokenHandler.WriteToken(token);
        //      }



        //      /////////////////////////////////////////////////////
        //      ///
        //      builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //  .AddJwtBearer(options =>
        //  {
        //          options.TokenValidationParameters = new TokenValidationParameters
        //          {
        //              ValidateIssuerSigningKey = true,
        //              IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
        //                  builder.Configuration.GetSection("AppSettings:Token").Value!)),
        //              ValidateIssuer = false,
        //              ValidateAudience = false
        //          };
        //      });


        //      ////////////////////////////////////////////////////////////////////
        //      ///

        //"AppSettings": {
        //  "Token": "my top secret key"
        //}



        ////////////////////////////////////////////
        ///
    //    c =>
//{
    // Define the security scheme (JWT Bearer Token)
   // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
   // {//
       // Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
       // Name = "Authorization",
        //In = ParameterLocation.Header,
      //  Type = SecuritySchemeType.Http,
       // Scheme = "Bearer"
   // });

    // Define the operation filter to add the Authorization header to each request
   // c.OperationFilter<SecurityRequirementsOperationFilter>();

    // Other Swagger configurations (if any)
//}


    }
}
