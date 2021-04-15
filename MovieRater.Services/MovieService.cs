using MovieRater.Data;
using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class MovieService
    {
        //setting up movie services for ctor injection
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovie(MovieCreate movie)
        {
            //ready to map movie into a new Movie
            var entity = new Movie
            {
                OwnerId = _userId,
                Title = movie.Title

            };

            using(var ctx=new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
