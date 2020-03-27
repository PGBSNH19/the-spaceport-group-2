using SpacePark.Library.Context;
using SpacePark.Library.Models;
using SpacePark;
using System.Linq;
using System;
using Xunit;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Fact]
        public void CheckAnyResponseValue()
        {
            var isAnyValue = PeopleAPI.GetStarWarsCharacters("Yoda");

            Assert.NotNull(isAnyValue);
        }

        [Fact]
        public void CheckThatPersonIsInSWAPI()
        {
            var isStarwarsPerson = PeopleAPI.GetStarWarsCharacters("Yoda");

            Assert.Equal("Yoda", isStarwarsPerson.Result.VisitorResult[0].Name);
        }

        [Fact]
        public void CheckThatStarShipIsInSWAPI()
        {
            var isStarshipValid = StarwarsAPI.ProcessSpaceShips("Death Star");

            Assert.Equal("Death Star", isStarshipValid.Result.Spaceships[0].Name);
        }
    }
}