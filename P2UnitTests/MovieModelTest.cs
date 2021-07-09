using Microsoft.EntityFrameworkCore;
using ModelsLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MovieTest = BusinessLayer.MovieService;

namespace P2UnitTests
{
	public class MovieModelTest
	{
		//create the in-memory Db //  installed EF Core
		DbContextOptions<P2Context> options = new DbContextOptionsBuilder<P2Context>()
		.UseInMemoryDatabase(databaseName: "TestingDb")
		.Options;
		// Movie test 
		[Fact]
		public async Task RenderAllMoviesCorrectly()
		{
			// arrange
			//createa a player to inset into the inmemory db.
			Movie m1 = new Movie()
			{
				MovieId = "a1",
				MovieName = "Aqua Men"
			};
			Movie m2 = new Movie() { MovieId = "a2", MovieName = "Black panther " };
			//bool result0 = false;
			List<Movie> result = new List<Movie>();

			using (var context = new P2Context(options))
			{
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.
				context.Movies.Add(m1);
				context.Movies.Add(m2);
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
				MovieTest movieListTest = new MovieTest(context);
				context.Movies.Add(m1);
				context.Movies.Add(m2);
				context.SaveChanges();
				// result0 = await movieListTest.RegisterUserAsync(u);
				// context.SaveChanges();
				// result0 = await userListTest.RegisterUserAsync(uu);
				// context.SaveChanges();

				result = await movieListTest.MovieListAsync();
				int movieCount = await context.Movies.CountAsync();

				// context.SaveChanges();


				//assert
				// verify the the result was as expected
				Assert.Equal(2, movieCount);

			}
		}
	}
}
