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

        private PlayerResult _player;

        public ShopController(ITokenStore tokenStore, IItemApi itemApi, IPlayerApi playerApi, IGameApi gameApi,PlayerResult pr, IPlayerStore playerStore)
        {
            _tokenStore = tokenStore;
            _itemApi = itemApi;
            _playerApi = playerApi;
            _gameApi = gameApi;
            _player = pr;
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

            return View(result.Data);
        }

        public async Task<ActionResult> Buy(int playerId, int itemId)
        {
            var buyResult = await _gameApi.BuyAsync(playerId, itemId);
            if (buyResult.IsSuccess)
            {
                RedirectToAction(controllerName: "Game", actionName: "Game");
            }
            return RedirectToAction("Shop");
        }

    }
}
