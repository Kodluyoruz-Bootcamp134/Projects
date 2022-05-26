using Base.Api.Domain.Entities;

namespace Base.Api.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}