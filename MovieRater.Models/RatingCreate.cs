using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class RatingCreate
    {
        [Required, Range(0, 5)]
        public double StarRating { get; set; }
        public int? MovieId { get; set; }
        public int? TVShowId { get; set; }
    }
}
