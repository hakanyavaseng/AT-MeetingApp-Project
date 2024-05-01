using AutoMapper;
using MeetingApp.Data.Repositories.Abstractions;
using MeetingApp.Entity.DTOs.User;
using MeetingApp.Entity.Entities;
using MeetingApp.Entity.Entities.Identity;
using MeetingApp.Service.Auth;
using MeetingApp.Service.Mail;
using MeetingApp.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace MeetingApp.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMailService _mailService;

        public UserService(IMapper mapper, UserManager<AppUser> userManager, ITokenService tokenService, IMailService mailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
            _mailService = mailService;
        }
        public async Task<bool> CreateUserAsync(UserAddDto userAddDto)
        {

            AppUser entityToAdd = _mapper.Map<AppUser>(userAddDto);
            IdentityResult result = await _userManager.CreateAsync(entityToAdd, userAddDto.Password);

            if (result.Succeeded)
            {
               // await _mailService.SendMailAsync(userAddDto.Email, "Your registration has been completed!", $@"Dear {userAddDto.FirstName} {userAddDto.LastName}, welcome to MeetingApp!");
                return true;
            }
            return false;
        }

        public async Task<UserLoginResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            AppUser? user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if(user is null)
                throw new ArgumentNullException(nameof(user));

            bool checkPassword = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);
            if (!checkPassword)
                throw new InvalidOperationException("Email or password is wrong!");

            JwtSecurityToken token = await _tokenService.CreateToken(user);
            string _token = new JwtSecurityTokenHandler().WriteToken(token);
            
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new UserLoginResponseDto()
            {
                Token = _token,
            };
        }
    }
}
