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
    public class RatingController : ApiController
    {
        private RatingServices CreateRatingService()
        {
            var ratingService = new RatingServices();
            return ratingService;
        }

        public IHttpActionResult Get()
        {
            RatingServices ratingService = CreateRatingService();
            var ratings = ratingService.GetRatings();
            return Ok(ratings);
        }

        public IHttpActionResult Post(RatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.Create(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            RatingServices ratingService = CreateRatingService();
            var rating = ratingService.GetRatingById(id);
            return Ok(rating);
        }

        public IHttpActionResult Put(RatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRatingService();

            if (!service.UpdateRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRatingService();

            if (!service.DeleteRating(id))
                return InternalServerError();

            return Ok();
        }

    }
}
