using MeetingApp.Entity.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace MeetingApp.Service.Auth
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(AppUser user);
    }
}