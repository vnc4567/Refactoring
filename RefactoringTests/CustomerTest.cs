using FluentAssertions;
using RefactoringWorkshop;
using System;
using System.Collections.Generic;
using Xunit;

namespace RefactoringTests
{
    public class CustomerTest
    {
        private readonly Customer _sut;

        public CustomerTest()
        {
            _sut = new()
            {
                Rentals = new List<Rental>
                {
                    new(){DaysRented = 4,Name="rental1",Tape = new(){Movie = new(){PriceCode = 0,}}},
                    new(){DaysRented = 7,Name="rental2",Tape = new(){Movie = new(){PriceCode = 1,}}},
                    new(){DaysRented = 1,Name="rental3",Tape = new(){Movie = new(){PriceCode = 2,}}},
                }
            };
        }

        [Fact]
        public void Should_GetStatementAmount()
        {
            string result = _sut.Statement();

            result.Should().Be("Rental Record for no name no name5 no name21 no name1,5 Amount owed is 27,5 You earned 4 frequent renter points");
        }
    }
}
