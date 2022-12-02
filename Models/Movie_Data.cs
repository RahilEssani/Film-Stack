namespace FilmStack.Models
{
    public class Movie_Data
    {
        public string MovieID { get; set; }
        public string Title { set; get; }
        public string Year { set; get; }
        public string Genre { set; get; }
        public IFormFile Image { get; set; }
        public string Crew { get; set; }
        public string IMDbRating { get; set; }
    }
}
