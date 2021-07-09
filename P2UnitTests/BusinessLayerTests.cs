using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using RepositoryLayer;
using ModelsLayer;

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
      //
    }

    [Fact]
    public async Task UpdateTheaterAsyncSuccessfullyUpdatesTheater()
    {
      //
    }

    [Fact]
    public void SelectTheatersSuccessfullySelectsAllTheaters()
    {
      //
    }

    [Fact]
    public void SelectTheaterSuccessfullySelectsSpecifiedTheater()
    {
      //
    }

    [Fact]
    public void SelectMovieScheduleSuccsfullySelectSpecifiedSchedule()
    {
      //
    }

    [Fact]
    public void TestCreateComment()
    {

    }
  }
}
