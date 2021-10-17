namespace RefactoringWorkshop.Refactored
{
    public class RentalRefactored : DomainObject, IRental
    {
        public int DaysRented { get; set; }
        public Tape Tape { get; set; }

        public double CalculAmountOfRental()
        {
            double result = 0;

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
