using System.Diagnostics;
using System.Security.Claims;
using ActionCommandGame.Api.Authentication.Model;
using ActionCommandGame.Sdk;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Services.Model.Filters;
using ActionCommandGame.Ui.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityApi _identityApi;
        private readonly IPlayerApi _playerApi;
        private readonly ITokenStore _tokenStore;

        public HomeController(IIdentityApi identityApi, ITokenStore tokenStore, IPlayerApi playerApi)
        {
            _identityApi = identityApi;
            _tokenStore = tokenStore;
            _playerApi = playerApi;
        }
        
        public IActionResult LoginPage()
        {
            return View();
        }


        [Route("/identity/sign-in")]
        public async Task<IActionResult> Login([FromForm] UserSignInRequest request)
        {
            var logInResult = await _identityApi.SignInAsync(request);

           if (logInResult.Success)
           {
                var token = logInResult.Token;

                if (token is null)
                {
                    ModelState.AddModelError("","Could not sign in.");
                    return View("LoginPage");
                }

                //Save token for later use in
                await _tokenStore.SaveTokenAsync(token);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, request.Email));
                identity.AddClaim(new Claim(ClaimTypes.Email, request.Email));
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("CharacterSelection");
           }
           else 
           {
               return View("LoginPage");
           }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _tokenStore.SaveTokenAsync(string.Empty);
            await HttpContext.SignOutAsync();

            return RedirectToAction("LoginPage");
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        [Route("/identity/register")]
        public async Task<IActionResult> Register([FromForm] UserRegistrationRequest registrationRequest)
        {

            var logInResult = await _identityApi.RegisterAsync(registrationRequest);

            if (logInResult.Success)
            {
                return View("LoginPage");
            }
            else
            {
                return View("RegisterPage");
            }

        }

        public async Task<IActionResult> CharacterSelectionAsync()
        {
            var players = await _playerApi.Find(new PlayerFilter() {FilterUserPlayers = true});
            
            return View(players.Data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}