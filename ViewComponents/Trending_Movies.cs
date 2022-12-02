using FilmStack.Models;
using FilmStack.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmStack.ViewComponents
{
	public class Trending_Movies: ViewComponent
	{
		private readonly IMovie _Movie;
		public Trending_Movies(IMovie obj)
		{
			_Movie = obj;
		}
        public IViewComponentResult Invoke(List<MostPopularDataDetail> items, bool flag= true)
		{
            foreach (var item in items)
            {
                var a = item.Image.Split("_V1_");
                item.Image = a[0] + "_V1_Ratio0.6716_AL_.jpg";
            }
            var list = new List<MostPopularDataDetail>();
            var rnd = new Random();
            if (!flag)
            {
                var newList = items.OrderBy(item => rnd.Next());
                list = newList.ToList().GetRange(1, 6);
                return View(list);
            }
            return View(items);
        }
	}
}
