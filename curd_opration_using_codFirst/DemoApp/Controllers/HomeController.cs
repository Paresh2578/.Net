using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly StudentDbContext studentDb;

        public HomeController(StudentDbContext studentDb)
        {
            this.studentDb = studentDb;
        }
       
        public IActionResult Index()
        {
            var stdList = studentDb.Students.ToList();
            return View(stdList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                studentDb.Students.Add(s);
                studentDb.SaveChanges();
                TempData["insertDataMassage"] = "insertSuccessfully";
                return RedirectToAction("Index" , "Home");
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || studentDb.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDb.Students.FirstOrDefaultAsync(x => x.id == id);
            return View(stdData);
        }

        public async Task<IActionResult> Delete(int id) 
        {
            var stdData = await studentDb.Students.FindAsync(id);
            if(stdData != null)
            {
                TempData["conformDelete"]= "<script>alert('delete std')</script>";
                 studentDb.Students.Remove(stdData);
            }
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var stdData = await studentDb.Students.FirstOrDefaultAsync(x => x.id == id);
            return View(stdData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id , Student s)
        {
            if (ModelState.IsValid)
            {
                studentDb.Update(s);
                await studentDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(s);
        }

    }
}
