using System.Diagnostics;
using ActionCommandGame.Api.Authentication.Model;
using ActionCommandGame.Sdk;
using ActionCommandGame.Ui.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IdentityApi _identityApi;

        public HomeController(IdentityApi identityApi)
        {
            _identityApi = identityApi;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        
        [Route("/identity/sign-in")]
        public async Task<IActionResult> Login([FromForm] UserSignInRequest signInRequest)
        {
           var logInResult = await _identityApi.SignInAsync(signInRequest);
            
            if (logInResult.Success)
            {
                return View("CharacterSelection");
            }
            else
            {
                return View("LoginPage");
            }
            
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        public async Task<IActionResult> Register([FromForm] UserRegistrationRequest registerRequest)
        {
            Console.WriteLine(registerRequest.Email);
            Console.WriteLine(registerRequest.Password);
            
            var registerResult = await _identityApi.RegisterAsync(registerRequest);
            
            if (registerResult.Success)
            {
                return View("LoginPage");
            }
            else
            {
                return View("RegisterPage");
            }
            
        }

        public IActionResult CharacterSelection()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}