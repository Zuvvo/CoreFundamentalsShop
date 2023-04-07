using Microsoft.AspNetCore.Mvc;

namespace CoreFundamentalsShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
