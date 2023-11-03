using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ticket_Web.Data;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _Context;
        private readonly AppSettings _AppSetting;

        public AuthenticationRepository(ApplicationDbContext context, IOptions<AppSettings> appSetting)
        {
            _Context = context;
            _AppSetting = appSetting.Value;
        }

        public User Authenticate(string userName, string password)
        {
            var userInDb = _Context.Users.FirstOrDefault(usr => usr.vUserName == userName && usr.vPassword == password);

            if (userInDb == null) return null;

            //Jwt Authentication Token

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_AppSetting.Secret);

            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userInDb.iUserId.ToString()),
                    new Claim(ClaimTypes.Role, userInDb.iRoleId.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_AppSetting.Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescritor);
            userInDb.Token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDescritor));

            //**
            userInDb.vPassword = "";
            return userInDb;

        }

        public bool IsUniqueUser(string userName)
        {
            if (_Context.Users.FirstOrDefault(usr => usr.vUserName == userName) == null) return false; return true;
        }
    }
}
