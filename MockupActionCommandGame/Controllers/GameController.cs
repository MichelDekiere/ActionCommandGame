using ActionCommandGame.Model;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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

            ViewData["playerId"] = id;

            return View(player.Data);
        }

        /*public async Task<IActionResult> Game(PlayerResult player)
        {
            return View(player);
        }*/



        public async Task<ActionResult> Explore(int playerId)
        {
            var result = await _gameApi.PerformActionAsync(playerId);

            var player = result.Data.Player;
            var positiveGameEvent = result.Data.PositiveGameEvent;
            var negativeGameEvent = result.Data.NegativeGameEvent;

            if (positiveGameEvent != null)
            {
                
                if (!string.IsNullOrWhiteSpace(positiveGameEvent.Description))
                {
                    Console.WriteLine(positiveGameEvent.Description);
                }
                if (positiveGameEvent.Money > 0)
                {
                    Console.WriteLine($"€{positiveGameEvent.Money}", ConsoleColor.Yellow, false);
                    Console.WriteLine(" has been added to your account.");
                }
            }

            if (negativeGameEvent != null)
            {
                Console.WriteLine(negativeGameEvent.Name, ConsoleColor.Blue);
                if (!string.IsNullOrWhiteSpace(negativeGameEvent.Description))
                {
                    Console.WriteLine(negativeGameEvent.Description);
                }
                Console.WriteLine(result.Data.NegativeGameEventMessages);
            }

            Console.WriteLine(result.Messages);

            return RedirectToAction("Game", result.Data.Player.Id);
        }
    }
}
