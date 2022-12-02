using FilmStack.Models.Interfaces;
using Flurl.Http;
using Newtonsoft.Json;

namespace FilmStack.Models
{
    public class MovieData : IMovie
    {
        private string[] keys = { "k_5isdehk0", "k_s69w4qvu", "k_mr9ponmk", "k_dz9k22w7", "k_13wkligm", "k_irwri65u" };
        private string SELECTED;
        private FilmStackDBContext FST;
        public MovieData()
        {
            SELECTED = keys[2];
            FST = new FilmStackDBContext();

        }
        public async Task<List<MostPopularDataDetail>> GetTrendingMovies()
        {
            string temp = String.Format("https://imdb-api.com/en/API/MostPopularMovies/{0}", SELECTED);
            var result = await temp.GetAsync();
            var list = await result.GetStringAsync();
            var values = JsonConvert.DeserializeObject<MostPopularData>(list);
            return values.Items;
        }

        public async Task<List<Top250DataDetail>> GetTopRatedMovie()
        {
            string temp = String.Format("https://imdb-api.com/en/API/Top250Movies/{0}", SELECTED);
            var result = await temp.GetAsync();
            var list = await result.GetStringAsync();
            var values = JsonConvert.DeserializeObject<Top250Data>(list);
            return values.Items;
        }

        public async Task<List<NewMovieDataDetail>> GetUpcomingMovie()

        {
            string temp = String.Format("https://imdb-api.com/en/API/InTheaters/{0}", SELECTED);
            var result = await temp.GetAsync();
            var list = await result.GetStringAsync();
            var values = JsonConvert.DeserializeObject<NewMovieData>(list);
            return values.Items;
        }
        public async Task<TitleData> GetMovieDetails(string MovieId)
        {
            string temp = String.Format("https://imdb-api.com/en/API/Title/{0}/{1}/FullActor,Posters,Images,Trailer,Ratings,Wikipedia,", SELECTED, MovieId);
            var result = await temp.GetAsync();
            var list = await result.GetStringAsync();
            TitleData value = JsonConvert.DeserializeObject<TitleData>(list);
            return value;
        }


        public void StoreComment(UserReview review)
        {
            review.Date = DateTime.Now;
            FST.UserReviews.Add(review);
            FST.SaveChanges();
        }
        //{
        //	FST.UserReviews.Add(review);
        //	FST.SaveChanges();
        public void DeleteComment(UserReview review)
        {
            throw new NotImplementedException();

            //FST.UserReviews.Attach(review);
            //FST.UserReviews.Remove(review);
            //FST.SaveChanges();
        }
        public List<UserReview> GetAllComment(string MovieID)
        {
            var comments = (from s in FST.UserReviews
                            where s.movieID == MovieID
                            select s);

            return comments.ToList();
        }

        public bool AddMovie(Admin_Movie admin_Movie)
        {
            try
            {
                var GetMovieCount = (from s in FST.AdminMovies
                                     where s.MovieID == admin_Movie.MovieID
                                     select s).Count();
                if (GetMovieCount <= 0)
                {
                    FST.AdminMovies.Add(admin_Movie);
                    FST.SaveChanges();
                    return true;

                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public List<Admin_Movie> GetMovies(string genre, string year)
        {
            try
            {
                var getMovies = (from s in FST.AdminMovies
                                 where (s.Genre == genre && s.Year == year)
                                 select s).ToList();
                if (getMovies.Count() > 0)
                {

                    return getMovies;

                }
                return null;
            }
            catch
            {
                return null;
            }
        }



        public int GetMoviesCount()
        {
            try
            {
                var getMovies = FST.AdminMovies.ToList();
                if (getMovies.Count() > 0)
                {

                    return getMovies.Count();

                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }




        public int GetUserReviewsCount()
        {
            try
            {
                var getMovies = FST.UserReviews.ToList();
                if (getMovies.Count() > 0)
                {

                    return getMovies.Count();

                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }



    }
}