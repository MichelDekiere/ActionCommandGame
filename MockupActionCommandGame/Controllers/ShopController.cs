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
        private readonly IGameApi _gameApi;

        private PlayerResult _player;

        public ShopController(ITokenStore tokenStore, IItemApi itemApi, IPlayerApi playerApi, IGameApi gameApi,PlayerResult pr)
        {
            _tokenStore = tokenStore;
            _itemApi = itemApi;
            _playerApi = playerApi;
            _gameApi = gameApi;
            //_player = pr;
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

        public async Task<ActionResult> Buy(int itemId)
        {
            var buyResult = _gameApi.BuyAsync(53, itemId);
            return RedirectToAction(controllerName: "Shop", actionName: "Shop", routeValues: _player);
        }

        public async Task<ActionResult> Leave()
        {
            return RedirectToAction(controllerName:"Game", actionName:"Game", routeValues:_player);
        }
    }
}
