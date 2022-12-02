using Microsoft.EntityFrameworkCore;

namespace FilmStack.Models
{
	public class FilmStackDBContext: DbContext
	{
		public DbSet<UserReview> UserReviews { get; set; }
		public DbSet<Admin_Movie> AdminMovies { get; set; }
		public DbSet<Signup> AdminSignups { get; set; }
		public DbSet<Login> AdminLogins { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FilmStack;Integrated Security=True;");
		}
	}
}
