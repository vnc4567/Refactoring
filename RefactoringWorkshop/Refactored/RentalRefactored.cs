using System;
using System.Collections.Generic;

namespace RefactoringWorkshop.Refactored
{
    public class RentalRefactored : DomainObject, IRental
    {
        public int DaysRented { get; set; }
        public Tape Tape { get; set; }

        private IReadOnlyDictionary<int, Func<double>> RuleCalculAmountByTypeMovie;

        public RentalRefactored()
        {
            RuleCalculAmountByTypeMovie = new Dictionary<int, Func<double>>
            {
                {Movie.Regular,()=> RegularCalcul() },
                {Movie.NewRelease,()=> NewReleaseCalcul() },
                {Movie.Childrens,()=> ChildrenCalcul() },
            };
        }

        public double CalculAmountOfRental() => CalculAmountByTypeMovie(Tape.Movie.PriceCode);

        private double ChildrenCalcul()
        {
            double result = 1.5;
            if (DaysRented > 3)
                result += (DaysRented - 3) * 1.5;
            return result;
        }

        private double NewReleaseCalcul()
        {
            return DaysRented * 3;
        }

        private double RegularCalcul()
        {
            double result = 2;
            if (DaysRented > 2)
                result += (DaysRented - 2) * 1.5;
            return result;
        }

        private double CalculAmountByTypeMovie(int typeMovie)
        {
            if (!RuleCalculAmountByTypeMovie.ContainsKey(typeMovie))
                return 0;

            return RuleCalculAmountByTypeMovie[typeMovie].Invoke();
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
