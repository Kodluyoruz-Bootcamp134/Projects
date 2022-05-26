using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Base.Api.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HashService _hashService;

        public IdentityService(IHttpContextAccessor httpContextAccessor, HashService hashService)
        {
            _httpContextAccessor = httpContextAccessor;
            _hashService = hashService;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirstValue("id");
        public int GetUserDecodeId => _hashService.Decode(_httpContextAccessor.HttpContext.User.FindFirstValue("id"));
        public string AppBaseUrl => $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }
}