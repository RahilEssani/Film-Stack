using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Flurl.Http;
using Newtonsoft.Json;
using FilmStack.Models;
using FilmStack.Models.Interfaces;
using AutoMapper;

namespace FilmStack.Controllers
{
    public class TrendingController : Controller
    {
        private readonly IMovie _Movie;
        private readonly IMapper _Mapper;
        public TrendingController(IMovie movie, IMapper mapper)
        {
            _Movie = movie;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            List<MostPopularDataDetail> items = _Movie.GetTrendingMovies().Result;
            return View(items);
        }
        [HttpGet]
        //[Route("Trending/FilmPage/{Id:Guid}")]
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
