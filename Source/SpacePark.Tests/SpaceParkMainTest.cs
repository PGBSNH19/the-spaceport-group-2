using SpacePark.Library.Models;
using Xunit;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Fact]
        public void CheckAnyResponseValue()
        {
            var isAnyValue = DataAPI.GetStarWarsCharacter("Yoda");

            Assert.NotNull(isAnyValue);
        }

        [Fact]
        public void CheckThatPersonIsInSWAPI()
        {
            var isStarwarsPerson = DataAPI.GetStarWarsCharacter("Yoda");

            Assert.Equal("Yoda", isStarwarsPerson.Result.VisitorResult[0].Name);
        }
    }
}