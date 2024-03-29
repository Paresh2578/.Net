using logInAndRegisterUsingSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;

namespace logInAndRegisterUsingSession.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserDbContext userDb;
        public AuthController(UserDbContext userDb)
        {
            this.userDb = userDb;
        }

        public IActionResult LogIn()
        {
            String userName = HttpContext.Session.GetString("userName");

            if(userName != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(User u)
        {
            Console.WriteLine($"Received data: {u.Email} , {u.Password}");//

            var userData = await userDb.Users.FirstOrDefaultAsync(x => x.Email == u.Email && x.Password == u.Password);

            if(userData != null)
            {
                TempData["success"] = "Login Successfully";
                HttpContext.Session.SetString("userName", userData.Name); 
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Invalid email or password";
            }

            return View();
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                userDb.Users.Add(u);
                userDb.SaveChanges();

                return RedirectToAction("LogIn", "Auth");
            }
          
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userName");

            return RedirectToAction("LogIn" , "Auth");
        }



    }
}
