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
        //private readonly Guid _userId;

        //public MovieService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateMovie(MovieCreate movie)
        {
            //ready to map movie into a new Movie
            var entity = new Movie
            {
               // OwnerId = _userId,
                Title = movie.Title

            };

            using(var ctx=new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Movies
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MovieListItem
                                {
                                    MovieId = e.MovieId,
                                    Title = e.Title,
                                    
                                }
                        );

                return query.ToArray();
            }
        }

        public MovieDetails GetMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == id /*&& e.OwnerId == _userId*/);
                return
                    new MovieDetails
                    {
                        MovieId = entity.MovieId,
                        Title = entity.Title,
                       
                    };
            }

        }

        public MovieDetails GetMovieByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.Title == title /*&& e.OwnerId == _userId*/);
                return
                    new MovieDetails
                    {
                        MovieId = entity.MovieId,
                        Title = entity.Title,

                    };
            }

        }

        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == model.MovieId /*&& e.OwnerId == _userId*/);

                entity.Title = model.Title;
               


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == noteId /*&& e.OwnerId == _userId*/);

                ctx.Movies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
