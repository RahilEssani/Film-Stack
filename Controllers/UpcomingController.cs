using FilmStack.Models;
using FilmStack.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace FilmStack.Controllers
{
    public class UpcomingController : Controller
    {
        private readonly IMovie _Movie;
        private readonly IMapper _Mapper;
        public UpcomingController(IMovie movie , IMapper mapper)
        {
            _Movie = movie;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            List<NewMovieDataDetail> items = _Movie.GetUpcomingMovie().Result;
            return View(items);
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
    }
}
