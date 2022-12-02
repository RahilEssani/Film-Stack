using FilmStack.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using Flurl.Http;
using Newtonsoft.Json;
using FilmStack.Models.Interfaces;
using FilmStack.Models.ViewModels;
using AutoMapper;

namespace FilmStack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovie _Movie;
        private readonly IMapper _Mapper;

        public HomeController(ILogger<HomeController> logger, IMovie movie, IMapper mapper)
        {
            _logger = logger;
            _Movie = movie;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            List<MostPopularDataDetail> items = _Movie.GetTrendingMovies().Result;
            List<Top250DataDetail> items1 = _Movie.GetTopRatedMovie().Result;
            List<NewMovieDataDetail> items2 = _Movie.GetUpcomingMovie().Result;
            CombinedModel model = new CombinedModel { Trending = items, TopRated = items1, Upcoming = items2 };
            return View(model);
        }
        [HttpGet]
        public IActionResult FilmPage(string Id)
        {
            TitleData result = _Movie.GetMovieDetails(Id).Result;
            Movie movieDetail = _Mapper.Map<Movie>(result);
            var comments = _Movie.GetAllComment(Id);
            ViewBag.Comments = comments;
            return View(movieDetail);
        }
        [Route("Home/AddComment")]
        public IActionResult AddComment([FromBody]CommentData review)
        {
            
            if (review.Name == "" || review.Comment == "")
            {
                return BadRequest("Enter required fields");
            }
            UserReview userRev = new UserReview { Comment = review.Comment, Name = review.Name, movieID = review.movieID };
            _Movie.StoreComment(userRev);
            return PartialView("_Review", review);

        }
      
        public IActionResult Search()
        {

            return View();

        }
        [HttpPost]
        public IActionResult SearchMovie(IFormCollection model)
        {
            var data = _Movie.GetMovies(model["genre"], model["year"]);
            Console.WriteLine(model["genre"]);
            Console.WriteLine(model["year"]);
            if (data!=null)
            {
                foreach(var movie in data)
                {
                    movie.Image = $"~/Uploads/{movie.MovieID}.jpeg";
                }
                return PartialView("_Search", data);
            }
            return Json("No Data Found");
        }

    }
}