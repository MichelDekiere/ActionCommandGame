﻿using System.Diagnostics;
using ActionCommandGame.Api.Authentication.Model;
using ActionCommandGame.Sdk;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Ui.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IdentityApi _identityApi;
        private readonly ITokenStore _tokenStore;

        public HomeController(IdentityApi identityApi, ITokenStore tokenStore)
        {
            _identityApi = identityApi;
            _tokenStore = tokenStore;
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
                var token = logInResult.Token;
                await _tokenStore.SaveTokenAsync(token);
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