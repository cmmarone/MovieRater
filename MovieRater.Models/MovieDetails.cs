using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class MovieDetails
    {
        public int MovieId { get; set; }

        
        public string Title { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();


    }
}
