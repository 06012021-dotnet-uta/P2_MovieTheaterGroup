using Microsoft.EntityFrameworkCore;
using ModelsLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TheaterMovieTest = BusinessLayer.TheaterMovieService;


namespace P2UnitTests
{
    public class TheaterMovieModelTest
    {
		//create the in-memory Db //  installed EF Core
		DbContextOptions<P2Context> options = new DbContextOptionsBuilder<P2Context>()
		.UseInMemoryDatabase(databaseName: "TestingDb")
		.Options;
		//Create TheaterMovie test
		[Fact]
		public async Task AddTheaterMovieInsertsTheaterMovieCorrectly()
		{
			// arrange
			//createa a TheaterMovie to inset into the inmemory db.
			// Theater t = new Theater()
			// {
			// 	TheaterId = 0,
			// 	TheaterLoc = "3038 Holland Bronx, NY 10467",
			// 	TheaterName = "AMC"
			// };
			// Movie m1 = new Movie()
			// {
			// 	MovieId = "A1", MovieName = "Aqua Men"
			// };

			TheaterMovie tm = new TheaterMovie(){
				TheaterId = 1, MovieId = "A1"
			};
			bool result = false;
			TheaterMovie th1;
			// act 
			using (var context = new P2Context(options))
			{
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.
				TheaterMovieTest theaterMovieTest = new (context);
				result = await theaterMovieTest.AddTheaterMovieAsync(tm);
				
				context.SaveChanges();
				th1 = context.TheaterMovies.Where(x => x.MovieId == "A1" 
									&& x.TheaterId == 1).FirstOrDefault();
			}

			// assert 
			using (var context = new P2Context(options))
			{
				
				int countTheaterMovie = await context.TheaterMovies.CountAsync();
				//u.UserId = 0;
				var p = context.TheaterMovies.Where(x => x.MovieId == "A1" 
									&& x.TheaterId == 1).FirstOrDefault();
				Assert.True(result);
				Assert.Equal(1, countTheaterMovie);
				Assert.NotNull(p);
				//Assert.Contains(u1, context.Users);
				//Assert.Equal(u1, p);

			}
		}

		//TheaterMovie test 
		[Fact]
		public async Task RenderAllTheaterMovieCorrectly()
		{
			// arrange
			//createa a player to inset into the inmemory db.
			Theater t = new Theater()
			{TheaterId = 100, TheaterLoc = "3038 Holland Bronx, NY 10467",
			 TheaterName = "AMC"};
			Movie m1 = new Movie()
			{MovieId = "A1", MovieName = "Aqua Men"};
			TheaterMovie th = new TheaterMovie() {  MovieId = "A1", TheaterId = 1 };
			TheaterMovie th1 = new TheaterMovie() { MovieId = "A1", TheaterId = 2 };
			
			//bool result0 = false;
			List<TheaterMovie> result = new List<TheaterMovie>();

			using (var context = new P2Context(options))
			{
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.
				//context.Movies.Add(m1);
				//context.SaveChanges();
				// context.Theaters.Add(t);
				// context.SaveChanges();
				context.TheaterMovies.Add(th);
				context.SaveChanges();
				context.TheaterMovies.Add(th1);
				context.SaveChanges();
			}
			// act
			// add to the In-Memory Db
			//instantiate the inmemory db
			using (var context = new P2Context(options))
			{
				//verify that the db was deleted and created anew
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.

				//instantiate the Class that we are going to unit test
				TheaterMovieTest theaterMovieTest = new TheaterMovieTest(context);
				//context.Movies.Add(m1);
				//context.SaveChanges();
				//context.Theaters.Add(t);
				//context.SaveChanges();
				context.TheaterMovies.Add(th);
				context.TheaterMovies.Add(th1);
				context.SaveChanges();

				result = await theaterMovieTest.TheaterMovieListAsync();
				int countTheaterMovie = await context.TheaterMovies.CountAsync();

				// context.SaveChanges();


				//assert
				// verify the the result was as expected
				Assert.Equal(2, countTheaterMovie);

			}
		}
	}
}
