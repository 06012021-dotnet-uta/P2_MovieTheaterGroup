using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using RepositoryLayer;
using ModelsLayer;
using System.Collections.Generic;
using MapperClasses;

namespace P2UnitTests
{
  public class BusinessLayerTests
  {
    DbContextOptions<P2Context> options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "testingDb").Options;

    [Fact]
    public async Task CreateTheaterInsertsTheaterCorrectlyAsync()
    {
      //Arrange
      Theater theater = new()
      {
        TheaterId = 1,
        TheaterLoc = "Kansas City",
        TheaterName = "Century"
      };

      //Act
      bool result = false;
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        TheaterService ThService = new(context);
        result = await ThService.CreateTheaterAsync(theater);

        context.SaveChanges();
      }

      //Assert
      using (var context = new P2Context(options))
      {
        Assert.True(result);

        int ct = await context.Theaters.CountAsync();
        Assert.Equal(1, ct);

        var ActualTheater = context.Theaters.Where(th => th.TheaterName == "Century").FirstOrDefault();
        Assert.NotNull(ActualTheater);
        Assert.Contains(ActualTheater, context.Theaters);
      }
    }

    [Fact]
    public async Task DeleteTheaterSuccessfullyRemovesTheaterFromDb()
    {
      //Arrange
      Theater theater = new()
      {
        TheaterId = 1,
        TheaterLoc = "Kansas City",
        TheaterName = "Century"
      };

      //Act
      bool result = false;
      int CtAfterAdd = 0;
      int CtAfterDelete = 0;
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        TheaterService ThService = new(context);
        await ThService.CreateTheaterAsync(theater);
        CtAfterAdd = await context.Theaters.CountAsync();
        result = await ThService.DeleteTheaterAsync(theater.TheaterId);
        CtAfterDelete = await context.Theaters.CountAsync();

        context.SaveChanges();
      }

      //Assert
      using (var context = new P2Context(options))
      {
        Assert.True(result);

        Assert.Equal(1, CtAfterAdd);
        Assert.Equal(0, CtAfterDelete);
      }
    }

    [Fact]
    public async Task UpdateTheaterAsyncSuccessfullyUpdatesTheater()
    {
      //Arrange
      Theater theater = new()
      {
        TheaterId = 1,
        TheaterLoc = "Kansas City",
        TheaterName = "Century"
      };

      //Act
      bool result1 = false;
      bool result2 = false;
      bool result3 = false;
      string ActualLoc = "";
      string ActualName = "";
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        TheaterService ThService = new(context);
        await ThService.CreateTheaterAsync(theater);
        result1 = await ThService.UpdateTheaterAsync(theater.TheaterId, theaterLoc: "Kentucky City");
        var ActualTheater = context.Theaters.Where(th => th.TheaterId == theater.TheaterId).FirstOrDefault();
        ActualLoc = ActualTheater.TheaterLoc;
        context.SaveChanges();
        result2 = await ThService.UpdateTheaterAsync(theater.TheaterId, theaterName: "Olympia");
        ActualTheater = context.Theaters.Where(th => th.TheaterId == theater.TheaterId).FirstOrDefault();
        ActualName = ActualTheater.TheaterName;
        context.SaveChanges();
        result3 = await ThService.UpdateTheaterAsync(theater.TheaterId);
        context.SaveChanges();
      }

      //Assert
      using (var context = new P2Context(options))
      {
        Assert.True(result1);
        Assert.True(result2);
        Assert.False(result3);
        Assert.Equal(theater.TheaterLoc, ActualLoc);
        Assert.Equal(theater.TheaterName, ActualName);
      }
    }

    [Fact]
    public async Task SelectTheatersSuccessfullySelectsAllTheaters()
    {
      //Arrange
      Theater theater1 = new()
      {
        TheaterId = 1,
        TheaterLoc = "Jersey City",
        TheaterName = "Century"
      };
      Theater theater2 = new()
      {
        TheaterId = 2,
        TheaterLoc = "Topeka",
        TheaterName = "Millenia"
      };

      //Act
      List<Theater> Theaters = new();
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        TheaterService ThService = new(context);
        await ThService.CreateTheaterAsync(theater1);
        await ThService.CreateTheaterAsync(theater2);
        Theaters = ThService.SelectTheaters();

        context.SaveChanges();
      }

      //Assert
      List<Theater> ExpectedResult = new()
      {
        theater1,
        theater2
      };
      using (var context = new P2Context(options))
      {
        Assert.Contains(theater1, Theaters);
        Assert.Contains(theater2, Theaters);
        Assert.Equal(ExpectedResult, Theaters);
      }
    }

    [Fact]
    public async Task SelectTheaterSuccessfullySelectsSpecifiedTheater()
    {
      //Arrange
      Theater theater = new()
      {
        TheaterId = 1,
        TheaterLoc = "Jersey City",
        TheaterName = "Century"
      };

      //Act
      Theater ActualTheater = new();
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        TheaterService ThService = new(context);
        await ThService.CreateTheaterAsync(theater);
        ActualTheater = ThService.SelectTheater(theater.TheaterId);

        context.SaveChanges();
      }

      //Assert
      using (var context = new P2Context(options))
      {
        Assert.Equal(theater, ActualTheater);
      }
    }

    [Fact]
    public void SelectMovieScheduleSuccsfullySelectSpecifiedSchedule()
    {
      //
    }

    [Fact]
    public async Task TestCreateComment()
            {
                    //Arrange
                    CommentMapBasic _comment = new()
                    {
                        Content = "For the lulz man!",
                        UserId = 5,
                        MovieId = "pfft"
                    };

                    //Act
                    using (var context = new P2Context(options))
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        CommentService comment = new(context);
                        await comment.CreateCommentAsync(_comment);
                        context.SaveChanges();
                    }

                    //Assert
                    using (var context = new P2Context(options))
                    {
                        var commentid = context.Comments.Select(x=>x.CommentId).FirstOrDefault();
                        Assert.Equal(1, commentid);

                        int ct = await context.Comments.CountAsync();
                        Assert.Equal(1, ct);

                        var content = context.Comments.Where(x => x.UserId == 5).FirstOrDefault();
                        Assert.Equal("pfft", content.MovieId);
                    }
                }

        [Fact]
        public async Task TestCreateGetAllCommentsForMovie()
        {
            //Arrange

            string movieid = "pfft";
            List<CommentMapWithUser> expectedresult = new();
            List<CommentMapWithUser> result = new();
            Comment _comment1 = new()
            {
                Content = "For the lulz man!",
                UserId = 4,
                MovieId = "pfft"
            };

            Comment _comment2 = new()
            {
                Content = "For the lulz man!",
                UserId = 5,
                MovieId = "pfft"
            };

            User _user1 = new()
            {
                UserId = 5,
                Username = "Bob"
            };

            User _user2 = new()
            {
                UserId = 4,
                Username = "Jay"
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Comments.Add(_comment1);
                context.Comments.Add(_comment2);
                context.Users.Add(_user2);
                context.Users.Add(_user1);
                await context.SaveChangesAsync();

                CommentService comment = new(context);
                result = comment.ReadCommentsForOneMovie(movieid);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                foreach (var comment in result)
                {
                    CommentMapWithUser usercomments = new()
                    {
                        CommentId = comment.CommentId,
                        UserId = comment.UserId,
                        Username = comment.Username,
                        DateMade = comment.DateMade,
                        Content = comment.Content,
                        MovieId = comment.MovieId
                    };
                    expectedresult.Add(usercomments);
                };
                int count = expectedresult.Count();
                Assert.Equal(2, count);
                foreach (var thing in expectedresult)
                {
                    string finalmovieid = thing.MovieId;
                    Assert.Equal("pfft", finalmovieid);
                }              
            }
        }

        [Fact]
        public async Task TestCreateGetAllCommentsForUser()
        {
            //Arrange

            int userid = 4;
            List<CommentMapWithMovie> expectedresult = new();
            List<CommentMapWithMovie> result = new();
            Comment _comment1 = new()
            {
                Content = "For the lulz man!",
                UserId = 4,
                MovieId = "pfft"
            };

            Comment _comment2 = new()
            {
                Content = "For the lulz man!",
                UserId = 4,
                MovieId = "lulz"
            };

            Movie _movie1 = new()
            {
                MovieId = "pfft",
                MovieName = "thugz"
            };

            Movie _movie2 = new()
            {
                MovieId = "lulz",
                MovieName = "4lyfe"
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Comments.Add(_comment1);
                context.Comments.Add(_comment2);
                context.Movies.Add(_movie2);
                context.Movies.Add(_movie1);
                await context.SaveChangesAsync();

                CommentService comment = new(context);
                result = comment.ReadCommentsForOneUser(userid);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                foreach (var comment in result)
                {
                    CommentMapWithMovie usercomments = new()
                    {
                        CommentId = comment.CommentId,
                        UserId = comment.UserId,
                        MovieName = comment.MovieName,
                        DateMade = comment.DateMade,
                        Content = comment.Content,
                        MovieId = comment.MovieId
                    };
                    expectedresult.Add(usercomments);
                };
                int count = expectedresult.Count();
                Assert.Equal(2, count);
                foreach (var thing in expectedresult)
                {
                    int finaluserid = thing.UserId;
                    Assert.Equal(4, finaluserid);
                }
            }
        }

        [Fact]
        public async Task TestUpdateComment()
        {
            //Arrange
            Comment _comment1 = new()
            {
                CommentId = 1,
                Content = "For the lulz man!",
            };

            CommentMapUpdate _comment2 = new()
            {
                CommentId = 1,
                Content = "oh snap!",
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Comments.Add(_comment1);
                await context.SaveChangesAsync();

                CommentService comment = new(context);
                await comment.UpdateCommentAsync(_comment2);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                var commentid = context.Comments.Select(x => x.CommentId).FirstOrDefault();
                Assert.Equal(1, commentid);

                int ct = await context.Comments.CountAsync();
                Assert.Equal(1, ct);

                var content = context.Comments.Select(x=>x.Content).FirstOrDefault();
                Assert.Equal(_comment2.Content, content);
            }
        }

        [Fact]
        public async Task TestDeleteComment()
        {
            //Arrange
            int commentid = 1;
            Comment _comment1 = new()
            {
                CommentId = 1,
                Content = "For the lulz man!",
            };

            Comment _comment2 = new()
            {
                CommentId = 2,
                Content = "oh snap!",
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Comments.Add(_comment1);
                context.Comments.Add(_comment2);
                await context.SaveChangesAsync();

                CommentService comment = new(context);
                await comment.DeleteCommentAsync(commentid);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                var _commentid = context.Comments.Select(x => x.CommentId).FirstOrDefault();
                Assert.Equal(2, _commentid);

                int ct = await context.Comments.CountAsync();
                Assert.Equal(1, ct);
            }
        }

        [Fact]
        public async Task TestCreateRating()
        {
            //Arrange
            RatingMapBasic _rating = new()
            {
                Content = 5,
                UserId = 5,
                MovieId = "pfft"
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                RatingService comment = new(context);
                await comment.CreateRatingAsync(_rating);
                context.SaveChanges();
            }

            //Assert
            using (var context = new P2Context(options))
            {
                var ratingid = context.Ratings.Select(x => x.RatingId).FirstOrDefault();
                Assert.Equal(1, ratingid);

                int ct = await context.Ratings.CountAsync();
                Assert.Equal(1, ct);

                var content = context.Ratings.Where(x => x.UserId == 5).FirstOrDefault();
                Assert.Equal("pfft", content.MovieId);
            }
        }

        [Fact]
        public async Task TestRatingGetAllCommentsForMovie()
        {
            //Arrange

            string movieid = "pfft";
            List<RatingMapWithUser> expectedresult = new();
            List<RatingMapWithUser> result = new();
            Rating _rating1 = new()
            {
                Content = 5,
                UserId = 4,
                MovieId = "pfft"
            };

            Rating _rating2 = new()
            {
                Content = 5,
                UserId = 5,
                MovieId = "pfft"
            };

            User _user1 = new()
            {
                UserId = 5,
                Username = "Bob"
            };

            User _user2 = new()
            {
                UserId = 4,
                Username = "Jay"
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Ratings.Add(_rating1);
                context.Ratings.Add(_rating2);
                context.Users.Add(_user2);
                context.Users.Add(_user1);
                await context.SaveChangesAsync();

                RatingService comment = new(context);
                result = comment.ReadRatingsForOneMovie(movieid);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                foreach (var rating in result)
                {
                    RatingMapWithUser userratings = new()
                    {
                        RatingId = rating.RatingId,
                        UserId = rating.UserId,
                        Username = rating.Username,
                        DateMade = rating.DateMade,
                        Content = rating.Content,
                        MovieId = rating.MovieId
                    };
                    expectedresult.Add(userratings);
                };
                int count = expectedresult.Count();
                Assert.Equal(2, count);
                foreach (var thing in expectedresult)
                {
                    string finalmovieid = thing.MovieId;
                    Assert.Equal("pfft", finalmovieid);
                }
            }
        }

        [Fact]
        public async Task TestRatingGetAllCommentsForUser()
        {
            //Arrange

            int userid = 4;
            List<RatingMapWithMovie> expectedresult = new();
            List<RatingMapWithMovie> result = new();
            Rating _rating1 = new()
            {
                Content = 5,
                UserId = 4,
                MovieId = "pfft"
            };

            Rating _rating2 = new()
            {
                Content = 5,
                UserId = 4,
                MovieId = "lulz"
            };

            Movie _movie1 = new()
            {
                MovieId = "pfft",
                MovieName = "thugz"
            };

            Movie _movie2 = new()
            {
                MovieId = "lulz",
                MovieName = "4lyfe"
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Ratings.Add(_rating1);
                context.Ratings.Add(_rating2);
                context.Movies.Add(_movie2);
                context.Movies.Add(_movie1);
                await context.SaveChangesAsync();

                RatingService comment = new(context);
                result = comment.ReadRatingsForOneUser(userid);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                foreach (var rating in result)
                {
                    RatingMapWithMovie userratings = new()
                    {
                        RatingId = rating.RatingId,
                        UserId = rating.UserId,
                        MovieName = rating.MovieName,
                        DateMade = rating.DateMade,
                        Content = rating.Content,
                        MovieId = rating.MovieId
                    };
                    expectedresult.Add(userratings);
                };
                int count = expectedresult.Count();
                Assert.Equal(2, count);
                foreach (var thing in expectedresult)
                {
                    int finaluserid = thing.UserId;
                    Assert.Equal(4, finaluserid);
                }
            }
        }

        [Fact]
        public async Task TestUpdateRating()
        {
            //Arrange
            Rating _rating1 = new()
            {
                RatingId = 1,
                Content = 5,
            };

            RatingMapUpdate _rating2 = new()
            {
                RatingId = 1,
                Content = 3,
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Ratings.Add(_rating1);
                await context.SaveChangesAsync();

                RatingService rating = new(context);
                await rating.UpdateRatingAsync(_rating2);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                var ratingid = context.Ratings.Select(x => x.RatingId).FirstOrDefault();
                Assert.Equal(1, ratingid);

                int ct = await context.Ratings.CountAsync();
                Assert.Equal(1, ct);

                var content = context.Ratings.Select(x => x.Content).FirstOrDefault();
                Assert.Equal(_rating2.Content, content);
            }
        }

        [Fact]
        public async Task TestDeleteRating()
        {
            //Arrange
            int ratingid = 1;
            Rating _rating1 = new()
            {
                RatingId = 1,
                Content = 5,
            };

            Rating _rating2 = new()
            {
                RatingId = 2,
                Content = 4,
            };

            //Act
            using (var context = new P2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Ratings.Add(_rating1);
                context.Ratings.Add(_rating2);
                await context.SaveChangesAsync();

                RatingService comment = new(context);
                await comment.DeleteRatingAsync(ratingid);
            }

            //Assert
            using (var context = new P2Context(options))
            {
                var _ratingid = context.Ratings.Select(x => x.RatingId).FirstOrDefault();
                Assert.Equal(2, _ratingid);

                int ct = await context.Ratings.CountAsync();
                Assert.Equal(1, ct);
            }
        }
    }
  }
