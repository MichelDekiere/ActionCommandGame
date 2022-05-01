/*using ActionCommandGame.Ui.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult LoginPage(string returnUrl)
        {
            var signInModel = new SignInModel
            {
                ReturnUrl = returnUrl
            };
            return View(signInModel);
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage(SignInModel signInModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(signInModel.Username, signInModel.Password,
                signInModel.RememberMe, false);
            if (signInResult.Succeeded)
            {
                return RedirectToLocal(signInModel.ReturnUrl);
            }

            ModelState.AddModelError("", "Username/Password combination is not correct.");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _signInManager.SignOutAsync();

            return RedirectToLocal(returnUrl);
        }

        *//*[HttpGet]
        public IActionResult RegisterPage(string returnUrl)
        {
            var registerModel = new RegisterModel
            {
                ReturnUrl = returnUrl
            };
            return View(registerModel);
        }*/

        /*[HttpPost]
        public async Task<IActionResult> RegisterPage(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var identityUser = new IdentityUser(registerModel.Username);

            var userCreateResult = await _userManager.CreateAsync(identityUser, registerModel.Password);

            if (userCreateResult.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(registerModel.Username, registerModel.Password, false, false);
                return RedirectToLocal(registerModel.ReturnUrl);
            }

            return View(registerModel);
        }*//*

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return LocalRedirect(returnUrl);
        }
    }

}
*/