using System.Security.Claims;
using ActionCommandGame.Sdk;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ITokenStore _tokenStore;
        private readonly IItemApi _itemApi;

        public ShopController(ITokenStore tokenStore, IItemApi itemApi)
        {
            _tokenStore = tokenStore;
            _itemApi = itemApi;
        }
        
        public async Task<ActionResult> Shop()
        {
            var result = await _itemApi.FindAsync();

            if (!result.IsSuccess)
            {
                return RedirectToAction(controllerName: "Game", actionName: "Game");
            }

            return View(result.Data);
        }
    }
}
