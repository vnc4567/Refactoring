using System;
using System.Collections.Generic;

namespace RefactoringWorkshop
{
    public class Rental : DomainObject
    {
        public int DaysRented { get; set; }
        public Tape Tape { get; set; }

        public  double CalculAmountOfRental()
        {
            double result = 0;
            //determine amounts for each line
            switch (Tape.Movie.PriceCode)
            {
                case Movie.Regular:
                    result += 2;
                    if (DaysRented > 2)
                        result += (DaysRented - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    result += DaysRented * 3;
                    break;
                case Movie.Childrens:
                    result += 1.5;
                    if (DaysRented > 3)
                        result += (DaysRented - 3) * 1.5;
                    break;

            }

            return result;
        }

        public int GetFrequentRenterPoints()
        {
            if ((Tape.Movie.PriceCode == Movie.NewRelease) && DaysRented > 1)
                return 2;

            return 1;
        }

        public string GetAmountByMovie() =>
          Tape.Movie.Name + CalculAmountOfRental() + " ";
    }
}
