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
        private readonly IPlayerStore _playerStore;
        private readonly IItemApi _itemApi;
        private readonly IPlayerApi _playerApi;
        private readonly IGameApi _gameApi;

        public ShopController(ITokenStore tokenStore, IItemApi itemApi, IPlayerApi playerApi, IGameApi gameApi, IPlayerStore playerStore)
        {
            _tokenStore = tokenStore;
            _itemApi = itemApi;
            _playerApi = playerApi;
            _gameApi = gameApi;
            _playerStore = playerStore;

        }
        
        public async Task<ActionResult> Shop()
        {
            var playerId = await _playerStore.GetTokenAsync();
            var player = _playerApi.GetAsync(playerId);

            var result = await _itemApi.FindAsync();
            
            if (!result.IsSuccess)
            {
                return RedirectToAction(controllerName: "Game", actionName: "Game");
            }

            ViewData["Money"] = player.Result.Data.Money;

            return View(result.Data);
        }

        public async Task<ActionResult> Buy(int itemId)
        {
            var playerId = await _playerStore.GetTokenAsync();

            await _gameApi.BuyAsync(playerId, itemId);
            
            return RedirectToAction("Shop");
        }

    }
}
