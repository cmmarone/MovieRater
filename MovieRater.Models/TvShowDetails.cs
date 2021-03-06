using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class TvShowDetails
    {

        public int TvShowId { get; set; }
      
        public string Title { get; set; }
        public int Seasons { get; set; }
        public int Episode { get; set; }
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                //add all ratings
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.StarRating;
                }
                // get average from total

                return Ratings.Count > 0
                    ? Math.Round(totalAverageRating / Ratings.Count, 1)  // if Raiting.Count > 0
                    : 0; //if Raiting.Count is not > 0
            }
        }
    }
}
