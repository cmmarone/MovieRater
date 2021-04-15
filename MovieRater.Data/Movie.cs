using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double Rating
        {
            get
            {
                double totalAverageRating = 0;
               
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.StarRating;
                }
                
                return Ratings.Count > 0
                    ? Math.Round(totalAverageRating / Ratings.Count, 1) 
                      : 0; 
            }
        }
    }
}
