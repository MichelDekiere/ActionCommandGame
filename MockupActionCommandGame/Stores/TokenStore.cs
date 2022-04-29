using ActionCommandGame.Sdk.Abstractions;

namespace ActionCommandGame.Ui.WebApp.Stores
{
    public class TokenStore : ITokenStore
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenStore(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public async Task<string> GetTokenAsync()
        {
            if (_contextAccessor.HttpContext is null)
            {
                return string.Empty;
            }

            // Get Token from JWT Cookie
            if (_contextAccessor.HttpContext.Request.Cookies.ContainsKey("Jwt"))
            {
                var jwtToken = _contextAccessor.HttpContext.Request.Cookies["Jwt"];
                if (jwtToken is null)
                {
                    return string.Empty;
                }

                return jwtToken;
            }

            return string.Empty;
        }

        public async Task SaveTokenAsync(string token)
        {
            if (_contextAccessor.HttpContext is null)
            {
                return;
            }

            if (_contextAccessor.HttpContext.Request.Cookies.ContainsKey("Jwt"))
            {
                _contextAccessor.HttpContext.Response.Cookies.Delete("Jwt");
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true
            };

            _contextAccessor.HttpContext.Response.Cookies.Append("Jwt", token, cookieOptions);
        }


    }
}
