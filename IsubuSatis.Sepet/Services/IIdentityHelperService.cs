namespace IsubuSatis.Sepet.Services
{
    public interface IIdentityHelperService
    {
        string GetUserId();

    }

    public class IdentityHelperService : IIdentityHelperService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityHelperService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserId()
        {
            //var userId =  _httpContextAccessor.HttpContext.User.FindFirst("sub")?.Value;

            var userId = _httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

           return userId ?? string.Empty;
        }
    }
}
