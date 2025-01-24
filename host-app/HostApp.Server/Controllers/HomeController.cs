using Microsoft.AspNetCore.Mvc;

namespace HostApp.Server.Controllers 
{
    public class HomeController : Controller 
    {
        public IActionResult Index() 
        {
            return File("~/index.html", "text/html");
        }
    }
}