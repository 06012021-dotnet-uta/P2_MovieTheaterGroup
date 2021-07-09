using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLayer;
using RepositoryLayer;
using Xunit;
using LoginUserTest = BusinessLayer.UserService;

namespace P2UnitTests
{
	public class UserLoginTest
	{
		//create the in-memory Db //  installed EF Core
		DbContextOptions<P2Context> options = new DbContextOptionsBuilder<P2Context>()
		.UseInMemoryDatabase(databaseName: "TestingDb")
		.Options;

		[Fact]
		public async Task LoginExistingUserCorrectly()
		{
			// arrange
			//createa a player to inset into the inmemory db.
			User u = new User()
			{
				Username = "Max",
				Passwd = "Max",
				FirstName = "Max",
				LastName = "Max",
				RoleId = 0,
			};
			bool result = false;
			bool result1 = false;
			bool result2 = false;

			using (var context = new P2Context(options))
			{
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.
				context.Users.Add(u);
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
				LoginUserTest loginUserTest = new LoginUserTest(context);
				result = await loginUserTest.RegisterUserAsync(u);
				context.SaveChanges();
				result1 = await loginUserTest.UserLoginAsync(u);
				result2 = await loginUserTest.LoginAsync(u);

				//assert
				// verify the the result was as expected
				Assert.True(result);
				Assert.True(result1);
				Assert.True(result2);
			}
		}
	}
}
