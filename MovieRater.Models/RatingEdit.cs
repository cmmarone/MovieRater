using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class RatingEdit
    {
        public int RatingId { get; set; }

        [Range(0, 5)]
        public double StarRating { get; set; }
    }
}
