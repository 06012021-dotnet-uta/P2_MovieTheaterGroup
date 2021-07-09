using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLayer;
using RepositoryLayer;
using Xunit;
using UserTest = BusinessLayer.UserService;


namespace P2UnitTests
{
    public class UserModelTest
    {
		//create the in-memory Db //  installed EF Core
		DbContextOptions<P2Context> options = new DbContextOptionsBuilder<P2Context>()
		.UseInMemoryDatabase(databaseName: "TestingDb")
		.Options;

		[Fact]
		public async Task RegisterUserInsertsUserCorrectly()
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
			User u1;

			using (var context = new P2Context(options))
			{
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.
				context.Users.Add(u);
				context.SaveChanges();
				u1 = context.Users.Where(x => x.Username == "Max").FirstOrDefault();
			}

			// act
			// add to the In-Memory Db
			//instantiate the inmemory db
			using (var context = new P2Context(options))
			{
				//verify that the db was deleted and created anew
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.

				//instantiate the RpsGameClass that we are going to unit test
				UserTest userTest = new UserTest(context);
				result = await userTest.RegisterUserAsync(u);
				context.SaveChanges();
				//}

				//assert
				// verify the the result was as expected
				//using (var context = new RpsGameDb(options))
				//{
				int amt = await context.Users.CountAsync();
				u.UserId = 0;
				var p = context.Users.Where(x => x.Username == "Max").FirstOrDefault();
				Assert.True(result);
				Assert.Equal(1, amt);
				Assert.NotNull(p);
				Assert.Contains(u1, context.Users);
				Assert.Equal(u1, p);

			}
		}

		
	
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
						UserTest loginUserTest = new UserTest(context);
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
