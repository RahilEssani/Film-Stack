using FilmStack.Models;
using FilmStack.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmStack.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IAdmin _AdminOperations;
        public SignUpController(IAdmin admin)
        {
            _AdminOperations = admin;
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
        public IActionResult Authenticating(IFormCollection model)
        {
            if (!HttpContext.Session.Keys.Contains("userID"))
            {
                try
                {
                    Signup _User = new Signup();
                    _User.Name = model["name"];
                    _User.Password = model["password"];
                    _User.Country = model["country"];
                    _User.Email = model["email"];
                    if (_AdminOperations.StoreSignup(_User))
                    {
                        object data = "Request sent to Admin";
                        string imagePath = ChooseBackground(); ViewBag.imagePath = imagePath;
                        return View("Index",data);
                    }
                    else
                    {
                        object data = "Error Occured";
                        string imagePath = ChooseBackground(); ViewBag.imagePath = imagePath;
                        return View("Index",data);
                    };
                }
                catch (Exception ex)
                {
                    //Handle Exception
                    object data = "Error Occured";
                    string imagePath = ChooseBackground(); ViewBag.imagePath = imagePath;
                    return View("Index", data);
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
