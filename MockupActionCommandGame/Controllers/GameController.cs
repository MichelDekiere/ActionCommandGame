using ActionCommandGame.Model;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Services.Model.Results;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameApi _gameApi;
        private readonly IPlayerApi _playerApi;
        private readonly ITokenStore _tokenStore;

        

        public GameController(IGameApi gameApi, IPlayerApi playerApi, ITokenStore tokenStore)
        {
            _gameApi = gameApi;
            _tokenStore = tokenStore;
            _playerApi = playerApi;
        }

        public async Task<IActionResult> Game(PlayerResult player)
        {
            return View(player);
        }

        /*public async Task<IActionResult> Game(GameResult gameResult)
        {
            return View(gameResult.Player);
        }*/

        public async Task<IActionResult> Explore(int playerId)
        {
            var gameResult = _gameApi.PerformActionAsync(playerId);

            return RedirectToAction("Game", gameResult);
        }
    }
}
