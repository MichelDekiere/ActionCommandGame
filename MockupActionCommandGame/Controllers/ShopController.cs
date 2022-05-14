using System.Security.Claims;
using ActionCommandGame.Model;
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
        private readonly IPlayerApi _playerApi;
        
        private PlayerResult _player;

        public ShopController(ITokenStore tokenStore, IItemApi itemApi, IPlayerApi playerApi)
        {
            _tokenStore = tokenStore;
            _itemApi = itemApi;
            _playerApi = playerApi;

        }
        
        public async Task<ActionResult> Shop(PlayerResult player)
        {
            var result = await _itemApi.FindAsync();
            _player = player;

            if (!result.IsSuccess)
            {
                return RedirectToAction(controllerName: "Game", actionName: "Game", routeValues:_player);
            }

            return View(result.Data);
        }

        public async Task<ActionResult> Leave()
        {
            return RedirectToAction(controllerName:"Game", actionName:"Game", routeValues:_player);
        }
    }
}
