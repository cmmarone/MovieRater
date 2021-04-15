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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var Service = new MovieService(userId);
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

    }
}
