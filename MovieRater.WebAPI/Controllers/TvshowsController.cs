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
    public class TvshowsController : ApiController
    {
        
        private TvShowServices CreateTvShowServices()
        {
           // var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TvShowServices();
            return service;

        }

        [HttpPost]
        public IHttpActionResult Post(TvShowCreate model)
        {
            if (model is null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTvShowServices();
            bool isSucessful = service.CreateTvShow(model);
            if(isSucessful)
            {
                return Ok($"Customer Created: {model.Title}");
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            TvShowServices tvShowServices = CreateTvShowServices();
            var tvShows = tvShowServices.GetTvShows();
            return Ok(tvShows);
        }

        public IHttpActionResult Get(string title)
        {
            TvShowServices tvShowServices = CreateTvShowServices();
            var tvshow = tvShowServices.GetTvShowByTitle(title);
            return Ok(tvshow);
        }
    }

}
