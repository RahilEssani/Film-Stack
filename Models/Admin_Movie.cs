using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStack.Models
{
    public class Admin_Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MovieID { get; set; }
        public string Title { set; get; }
        public string Year { set; get; }
        public string Genre{ set; get; }
        public string Image { get; set; }
        public string Crew { get; set; }
        public string IMDbRating { get; set; }
    }
}
