using ActionCommandGame.Sdk.Abstractions;

namespace ActionCommandGame.Ui.WebApp.Stores
{
    public class TokenStore : ITokenStore
    {
        private const string TokenName = "Jwt";
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenStore(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Task<string> GetTokenAsync()
        {
            var httpContext = _contextAccessor.HttpContext;

            if (httpContext is null)
            {
                return Task.FromResult(string.Empty);
            }

            // Get Token from JWT Cookie
            httpContext.Request.Cookies.TryGetValue(TokenName, out string? token);
            
            var tokenResult = token ?? string.Empty;
            return Task.FromResult(tokenResult);
        }

        public Task SaveTokenAsync(string token)
        {
            var httpContext = _contextAccessor.HttpContext;

            if (httpContext is null)
            {
                return Task.FromResult(string.Empty);
            }

            if (httpContext.Request.Cookies.ContainsKey(TokenName))
            {
                httpContext.Response.Cookies.Delete(TokenName);
            }

            httpContext.Response.Cookies.Append(TokenName, token, new CookieOptions {HttpOnly = true});

            return Task.CompletedTask;
        }


    }
}
