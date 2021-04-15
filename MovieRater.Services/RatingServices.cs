using MovieRater.Data;
using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class RatingServices
    {

        public bool Create(RatingCreate model)
        {
            var entity = new Rating()
            {
                StarRating = model.StarRating,
                MovieId = (model.MovieId != null) ? model.MovieId : null,
                TVShowId = (model.TVShowId != null) ? model.TVShowId : null
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ratings
                        .Select(
                            e =>
                                new RatingListItem
                                {
                                    RatingId = e.RatingId,
                                    StarRating = e.StarRating
                                }
                        );
                return query.ToArray();
            }
        }

        public RatingListItem GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == id);
                return
                    new RatingListItem
                    {
                        RatingId = entity.RatingId,
                        StarRating = entity.StarRating
                    };
            }
        }

        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == model.RatingId);
                entity.RatingId = model.RatingId;
                entity.StarRating = model.StarRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == ratingId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
