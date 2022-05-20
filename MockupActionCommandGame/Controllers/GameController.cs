using ActionCommandGame.Model;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;
using ActionCommandGame.Ui.WebApp.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameApi _gameApi;
        private readonly IPlayerApi _playerApi;
        private readonly ITokenStore _tokenStore;
        private readonly IPlayerStore _playerStore;

        public GameController(IGameApi gameApi, IPlayerApi playerApi, ITokenStore tokenStore, IPlayerStore playerStore)
        {
            _gameApi = gameApi;
            _tokenStore = tokenStore;
            _playerStore = playerStore;
            _playerApi = playerApi;
        }

        public async Task<IActionResult> GameWithId(int id)
        {
            await _playerStore.SaveTokenAsync(id);
            var player = await _playerApi.GetAsync(id);

            var result = new PlayerAction()
            {
                Player = player.Data
            };

            return View("Game", result);
        }

        public async Task<IActionResult> Game()
        {
            var playerId = await _playerStore.GetTokenAsync();
            var player = await _playerApi.GetAsync(playerId);

            var result = new PlayerAction()
            {
                Player = player.Data
            };

            return View(result);
        }


        public async Task<ActionResult> Explore()
        {
            var playerId = await _playerStore.GetTokenAsync();

            if (playerId < 0)
            {
                return RedirectToAction(controllerName:"Home", actionName:"CharacterSelection");
            }
            var player = await _playerApi.GetAsync(playerId);
            if (!player.IsSuccess || player.Data is null)
            {
                return RedirectToAction(controllerName: "Home", actionName: "CharacterSelection");
            }
            var gameResult = await _gameApi.PerformActionAsync(playerId);
            if (!gameResult.IsSuccess || gameResult.Data is null)
            {
                var failResult = new PlayerAction()
                {
                    Player = player.Data,
                    
                };
                return RedirectToAction("Game", failResult);
            }

            var result = new PlayerAction()
            {
                Player = player.Data,
                GameResult = gameResult.Data,
                Messages = gameResult.Messages

            };
            return View("Game", result);
        }
    }
}
