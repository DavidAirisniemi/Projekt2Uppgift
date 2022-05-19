using Microsoft.AspNetCore.Mvc;

namespace TimeReportingAPI.Controllers
{
    public class TimeAndDateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
