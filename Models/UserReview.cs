using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStack.Models
{
    public partial class UserReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Comment { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Name { get; set; } = null!;

        public string movieID { get; set; } = null!;
    }
}
