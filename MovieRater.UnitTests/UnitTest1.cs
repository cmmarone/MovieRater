using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRater.Data;
using MovieRater.Models;
using MovieRater.Services;
using System;
using System.Linq;

namespace MovieRater.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetRatingsShouldReturnTypeDouble()
        {
            //arrange
            var rating1 = new RatingCreate();
            var ratingService = new RatingServices();
            rating1.StarRating = 3.3;
            rating1.MovieId = 1;
            ratingService.Create(rating1);

            //act
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
    }
}
