using FilmStack.Models;
using FilmStack.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace FilmStack.Controllers
{
    public class TopRatedController : Controller
    {
        private readonly IMovie _Movie;
        private readonly IMapper _Mapper;
        public TopRatedController(IMovie movie, IMapper mapper)
        {
            _Movie = movie;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            List<Top250DataDetail> items = _Movie.GetTopRatedMovie().Result;
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
