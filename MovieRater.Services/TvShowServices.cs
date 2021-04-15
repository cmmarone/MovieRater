using MovieRater.Data;
using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class TvShowServices
    {
        // private readonly Guid _userId;
        //   public TvShowServices (Guid userId)
        // {
        //   _userId = userId;
        //}

        public bool CreateTvShow(TvShowCreate model)
        {
            var tvShow = new TVShow
            {
                //  OwnerId =_userId,
                Title = model.Title,
                Seasons = model.Seasons,
                Episode = model.Episode

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TVShows.Add(tvShow);

                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<TvShowListItem> GetTvShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .TVShows
                    //   .Where(e => e.OwnerId == _userId)
                    .Select(e => new TvShowListItem
                    {
                        TvShowId = e.TvShowId,
                        Title = e.Title,
                        Ratings = e.Ratings,
                    });
                return query.ToArray();
            }
        }
        public TvShowDetails GetTvShowByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .TVShows
                    .Single(e => e.Title == title);
                return new TvShowDetails
                {
                    TvShowId = entity.TvShowId,
                    Title = entity.Title,
                    Seasons = entity.Seasons,
                    Episode = entity.Episode,
                    Ratings = entity.Ratings

                };
            }
        }

        public bool UpdateTvShow(TvShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .TVShows
                    .Single(e => e.TvShowId == model.TvShowId);

                entity.TvShowId = model.TvShowId;
                entity.Title = model.Title;
                entity.Seasons = model.Seasons;
                entity.Episode = model.Episode;
                entity.Ratings = model.Ratings;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTvShow(int tvShowId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .TVShows
                    .Single(e => e.TvShowId == tvShowId);

                ctx.TVShows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
