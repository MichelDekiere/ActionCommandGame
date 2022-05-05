using System.Security.Claims;
using ActionCommandGame.Sdk;
using ActionCommandGame.Sdk.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ITokenStore _tokenStore;

        public ShopController(ITokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }

        [Authorize]
        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bavo")
            };

            var identity = new ClaimsIdentity(claim, "authClaim");
            var principal = new ClaimsPrincipal(new[] { identity });

            HttpContext.SignInAsync(principal);

            return RedirectToAction("Shop");
        }
    }
}
