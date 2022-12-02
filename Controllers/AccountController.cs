using FilmStack.Models;
using FilmStack.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace FilmStack.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMovie _MovieOperations;
        private readonly IAdmin _AdminOperations;
        private readonly IWebHostEnvironment Environment;
        public AccountController(IMovie movieOperations, IWebHostEnvironment environment, IAdmin admin)
        {
            _MovieOperations = movieOperations;
            Environment = environment;
            _AdminOperations = admin;
        }


        [HttpGet, ResponseCache(NoStore = true)]
        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                string data = HttpContext.Session.GetString("userID");
                var user = _AdminOperations.GetUser(data);
                return View(user);
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Form()
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                return PartialView("_MovieForm");
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult PendingRequests()
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                var users = _AdminOperations.GetPendingRequests();
                return PartialView("_PendingList", users);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult AddUser(string Udata)
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                Console.WriteLine(Udata);
                var users = _AdminOperations.ApproveSignup(Udata);
                return Json("Success");
            }
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                var user = _AdminOperations.GetUser(HttpContext.Session.GetString("userID"));
                var movies = _MovieOperations.GetMoviesCount();
                var reviews = _MovieOperations.GetUserReviewsCount();
                ViewBag.MovieCount = movies;
                ViewBag.ReviewCount = reviews;
                return PartialView("_Dashboard",user);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult AddMovie(IFormCollection model, IFormFile Image)
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                try
                {
                    string wwwPath = this.Environment.WebRootPath;
                    string path = Path.Combine(wwwPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var fileName = Path.GetFileName(Image.FileName);
                    var pathWithFileName = Path.Combine(path, model["MovieID"] + ".jpeg");

                    //Access File Property to save it on server or upload to some storage
                    Admin_Movie _Movie = new Admin_Movie();
                    _Movie.Title = model["Title"];
                    _Movie.Year = model["Year"];
                    _Movie.MovieID = model["MovieID"];
                    _Movie.IMDbRating = model["Rating"];
                    _Movie.Genre = model["Genre"];
                    _Movie.Crew = model["Crew"];
                    _Movie.Image = pathWithFileName;
                    if (_MovieOperations.AddMovie(_Movie))
                    {
                        using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                        {
                            Image.CopyTo(stream);
                        }
                    }
                    else
                    {
                        return Json(new { Status = "Failed" });
                    };
                    // Write code to save information to database.
                }
                catch (Exception ex)
                {
                    //Handle Exception
                    return Json(new { Status = "Failed" });
                }

                return Json(new { Status = "Success" });
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet, ResponseCache(NoStore = true)]
        public IActionResult Logout()
        {
            if (HttpContext.Session.Keys.Contains("userID"))
            {
                HttpContext.Session.Remove("userID");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
