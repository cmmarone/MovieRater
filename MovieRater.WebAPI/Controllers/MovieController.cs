using Microsoft.AspNet.Identity;
using MovieRater.Models;
using MovieRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRater.WebAPI.Controllers
{  
    [Authorize]
    public class MovieController : ApiController
    {
        //helper method will perform ctor injection on movie services

        private MovieService CreateMovieService()
        {
           // var userId = Guid.Parse(User.Identity.GetUserId());
            var Service = new MovieService();
            return Service;
        }

        [HttpPost]
        public IHttpActionResult Post(MovieCreate movie)
        {
            if (movie is null)
            {
                return BadRequest();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Service = CreateMovieService();
            var isSuccessful = Service.CreateMovie(movie);
            if (!isSuccessful)
            {
                return InternalServerError();
            }
            return Ok("Movie Created");
            
        }

        public IHttpActionResult Get()
        {
            MovieService movieService = CreateMovieService();
            var movies = movieService.GetMovies();
            return Ok(movies);
        }
        public IHttpActionResult Get(int id)
        {
            MovieService noteService = CreateMovieService();
            var note = noteService.GetMovieById(id);
            return Ok(note);
        }

        
        //private MovieService CreateMovieService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var noteService = new NoteServices(userId);
        //    return noteService;
        //}

        public IHttpActionResult Put(MovieEdit movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieService();

            if (!service.UpdateMovie(movie))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMovieService();

            if (!service.DeleteMovie(id))
                return InternalServerError();

            return Ok();
        }

    }
}
