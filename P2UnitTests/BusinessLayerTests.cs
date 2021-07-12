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
    public async Task SelectMovieScheduleSuccessfullySelectSpecifiedSchedule()
    {
      //Arrange
      Schedule schedule1 = new()
      {
        TheaterId = 1,
        MovieId = "id",
        ShowingTime = DateTime.Now
      };
      Schedule schedule2 = new()
      {
        TheaterId = 1,
        MovieId = "id",
        ShowingTime = DateTime.Now.AddMinutes(20)
      };

      //Act
      List<Schedule> ActualSchedules = new();
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        ScheduleService SchService = new(context);
        await SchService.CreateScheduleAsync(schedule1);
        await SchService.CreateScheduleAsync(schedule2);
        ActualSchedules = SchService.SelectMovieSchedules("id", 1);

        context.SaveChanges();
      }

      //Assert
      List<Schedule> ExpectedSchedules = new()
      {
        schedule1,
        schedule2
      };
      using (var context = new P2Context(options))
      {
        Assert.Equal(ExpectedSchedules, ActualSchedules);
      }
    }

    [Fact]
    public async void CreateScheduleSuccessfullyCreatesSchedule()
    {
      //Arrange
      Schedule schedule = new()
      {
        TheaterId = 1,
        MovieId = "id",
        ShowingTime = DateTime.Now
      };

      //Act
      bool result = false;
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        ScheduleService SchService = new(context);
        result = await SchService.CreateScheduleAsync(schedule);

        context.SaveChanges();
      }

      //Assert
      using (var context = new P2Context(options))
      {
        Assert.True(result);

        int ct = await context.Schedules.CountAsync();
        Assert.Equal(1, ct);

        var ActualTheater = context.Schedules.Where(th => th.TheaterId == 1).FirstOrDefault();
        Assert.NotNull(ActualTheater);
        Assert.Contains(ActualTheater, context.Schedules);
      }
    }

    [Fact]
    public async Task DeleteScheduleSuccessfullyRemovesScheduleFromDb()
    {
      //Arrange
      Schedule schedule = new()
      {
        TheaterId = 1,
        MovieId = "id",
        ShowingTime = DateTime.Now
      };

      //Act
      bool result = false;
      int CtAfterAdd = 0;
      int CtAfterDelete = 0;
      using (var context = new P2Context(options))
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        ScheduleService SchService = new(context);
        await SchService.CreateScheduleAsync(schedule);
        CtAfterAdd = await context.Schedules.CountAsync();
        result = await SchService.DeleteScheduleAsync(schedule.ScheduleId);
        CtAfterDelete = await context.Schedules.CountAsync();

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
    public void TestCreateComment()
    {

    }
  }
}
