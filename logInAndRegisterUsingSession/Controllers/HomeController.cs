using logInAndRegisterUsingSession.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Session;

namespace logInAndRegisterUsingSession.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {

            String userName = HttpContext.Session.GetString("userName");

            Console.WriteLine($"userName {userName}");

            if(userName == null)
            {
                return RedirectToAction("LogIn", "Auth");
            }
            else
            {
                ViewBag.userName = userName;

            }



            return View();
        }

       
    }
}
