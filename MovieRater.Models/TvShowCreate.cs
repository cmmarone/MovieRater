using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
   public class TvShowCreate
    {
        [Required]
        public string Title { get; set; }
        public int Seasons { get; set; }
        public int Episode { get; set; }

    }
}
