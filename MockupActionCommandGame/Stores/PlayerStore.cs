using ActionCommandGame.Sdk.Abstractions;

namespace ActionCommandGame.Ui.WebApp.Stores
{
    public class PlayerStore : IPlayerStore
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _tokenName = "Player_id";

        public PlayerStore(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public Task<int> GetTokenAsync()
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return Task.FromResult(-1);
            }

            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(_tokenName, out string? token);
            var value = Task.FromResult(int.Parse(token ?? "-1"));
            return value;
        }

        public Task SaveTokenAsync(int token)
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return Task.FromResult(string.Empty);
            }

            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(_tokenName))
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(_tokenName);
            }
            _httpContextAccessor.HttpContext.Response.Cookies.Append(
                _tokenName,
                token.ToString(),
                new CookieOptions
                {
                    HttpOnly = true
                });

            return Task.CompletedTask;
        }
    }
}
