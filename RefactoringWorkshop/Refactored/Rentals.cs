using System.Collections.Generic;
using System.Linq;

namespace RefactoringWorkshop.Refactored
{
    public class Rentals : IRental
    {
        private readonly IList<RentalRefactored> _rentals;

        public Rentals(IList<RentalRefactored> rentals)
        {
            if (rentals == null) ;
            {
                _rentals = new List<RentalRefactored>();
            }

            _rentals = rentals;
        }

        public double CalculAmountOfRental() =>
             _rentals.Sum(p => p.CalculAmountOfRental());

        public int GetFrequentRenterPoints() =>
            _rentals.Sum(p => p.GetFrequentRenterPoints());

        public string GetAmountByMovie() =>
            string.Join("", _rentals.Select(p => p.GetAmountByMovie()));
    }
}
