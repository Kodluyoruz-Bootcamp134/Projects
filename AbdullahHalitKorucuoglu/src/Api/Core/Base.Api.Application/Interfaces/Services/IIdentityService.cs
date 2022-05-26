namespace Base.Api.Application.Services
{
    public interface IIdentityService
    {
        public string GetUserId { get; }
        public string AppBaseUrl { get; }
        public int GetUserDecodeId { get; }
        public bool IsAuthenticated { get; }
    }
}