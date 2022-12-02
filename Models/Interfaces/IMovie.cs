namespace FilmStack.Models.Interfaces
{
    public interface IMovie
    {
        public Task<List<MostPopularDataDetail>> GetTrendingMovies();

        public Task<List<Top250DataDetail>> GetTopRatedMovie();
        public Task<List<NewMovieDataDetail>> GetUpcomingMovie();

        public Task<TitleData> GetMovieDetails(string MovieId);
        public void StoreComment(UserReview review);
        public void DeleteComment(UserReview review);
        public bool AddMovie(Admin_Movie admin_Movie);
        public List<Admin_Movie> GetMovies(string genre, string year);
        public int GetMoviesCount();
        public int GetUserReviewsCount();
        public List<UserReview> GetAllComment(string MovieID);
    }
}
