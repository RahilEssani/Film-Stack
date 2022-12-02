using FilmStack.Models;
using FilmStack.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmStack.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdmin _AdminOperations; 
        public LoginController(IAdmin adminOperations)
        {
            _AdminOperations = adminOperations;
        }
        [HttpGet, ResponseCache(NoStore = true)]
        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                return RedirectToAction("Index", "Account");
            }
            string imagePath = ChooseBackground(); ViewBag.imagePath = imagePath;
            return View();
        }
        [HttpPost, ResponseCache(NoStore = true)]
        public IActionResult LoginAuthenticate(IFormCollection model)
        {
            if (!HttpContext.Session.Keys.Contains("userID"))
            {
                try
                {
                        Login _User = new Login();
                        _User.Password = model["password"];
                        _User.Email = model["email"];
                        if (_AdminOperations.ValidateUser(_User))
                        {
                            HttpContext.Session.SetString("userID", _User.Email);
                            return RedirectToAction("Index", "Account");
                        }
                    string imagePath = ChooseBackground(); ViewBag.imagePath = imagePath;
                    object data = "No User Found";
                    return RedirectToAction("Index", data);
                    // Write code to save information to database.
                }
                catch (Exception ex)
                {
                    string imagePath = ChooseBackground(); ViewBag.imagePath = imagePath;
                    object data = "No User Found";
                    return RedirectToAction("Index", data);
                    //Handle Exception

                }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

        }
        private string ChooseBackground()
        {
            string[] file = { "bg1", "bg2", "bg3", "bg4", "bg5", "bg6", "bg7", "bg9", "bg11", };
            Random rand = new Random();
            int index = rand.Next(file.Length);
            return file[index] + ".jpg";
        }
    }
}
