using HrApp.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using HrApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Runtime.InteropServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace HrApp.Application
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper mapper;

        public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.mapper = mapper;
        }

        public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var response = new LoginResponse();

            if (IsValidUser(command.Email, command.Password))
            {

                var user = await _userManager.FindByEmailAsync(command.Email);
                if (!user.IsActive)
                {
                    response.IsSuccess = false;
                    response.Message = "User is not active";
                    return response;
                }
                var roles = await _userManager.GetRolesAsync(user);

                response.Token = GenerateJwtToken(user, roles);

                return response;
            }
            response.IsSuccess = false;
            return response;
        }

        private bool IsValidUser(string username, string password)
        {
            var user = _userManager.FindByEmailAsync(username).Result;

            if (user != null)
            {
                var result = _signInManager.CheckPasswordSignInAsync(user, password, false).Result;
                return result.Succeeded;
            }
            return false;
        }



        private string GenerateJwtToken(AppUser user, IList<string> userRoles)
        {
            string _secretKey = "buraküzüldüyasarüzüldüburcuüzüldüutkuüzüldüsonraburakagladıasjdasjdlkajsldkjaslkdjalskdjalskdjlaksjdlaksjdlk";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Id),
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.Gender, user.GenderId.ToString()),
                    new Claim(ClaimTypes.Role, string.Join(",", userRoles)),
                    new Claim("company", user.CompanyId.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
