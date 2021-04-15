using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required, Range(0, 5)]
        public double StarRating { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey(nameof(TVShow))]
        public int TVShowId { get; set; }
        public virtual TVShow TVShow { get; set; }
    }
}
