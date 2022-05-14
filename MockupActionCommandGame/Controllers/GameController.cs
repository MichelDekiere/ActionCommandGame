using ActionCommandGame.Sdk.Abstractions;
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

        public async Task<IActionResult> Game(int id)
        {
            var player = await _playerApi.GetAsync(id);
            return View(player.Data);
        }
    }
}
