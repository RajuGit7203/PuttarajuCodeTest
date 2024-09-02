//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mouri.Shared.Service
//{
//    public class UserService : IUserService
//    {
//        private List<User> users = new List<User>
//       {
//           new User {UserName="Admin", PassWord="PassWord"}
//       };
//        private readonly IConfiguration _configuration;

//        public string Login(User user)
//        {
//            var LoginUser = users.SingleOrDefault(x => x.UserName == user.UserName && x.PassWord == user.PassWord);

//            if (LoginUser == null)
//            {
//                return string.Empty;
//            }

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[]
//                {
//                    new Claim(ClaimTypes.Name, user.UserName)
//                }),
//                Expires = DateTime.UtcNow.AddMinutes(30),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            string userToken = tokenHandler.WriteToken(token);
//            return userToken;
//        }
//    }
//}
