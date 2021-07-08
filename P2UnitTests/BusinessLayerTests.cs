using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using P2DatabaseModelLibrary;
using System.Linq;
using System.Threading.Tasks;

namespace P2UnitTests
{
  public class UnitTest
  {
    DbContextOptions<P2Context> options = new DbContextOptionsBuilder<P2Context>().UseInMemoryDatabase(databaseName: "testingDb").Options;

    [Fact]
    public void TestCreateComment()
    {

    }
  }
}
