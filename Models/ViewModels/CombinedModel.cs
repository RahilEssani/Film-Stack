namespace FilmStack.Models.ViewModels
{
	public class CombinedModel
	{
		public List<MostPopularDataDetail> Trending { get; set; }
		public List<Top250DataDetail> TopRated { get; set; }
		public List<NewMovieDataDetail> Upcoming { get; set; }
	}
}
