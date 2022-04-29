using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Ui.WebApp.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Game()
        {
            return View();
        }
    }
}
