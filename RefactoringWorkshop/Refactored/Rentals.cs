using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringWorkshop.Refactored
{
    public class Rentals
    {
        private IList<Rental> _rentals;

        public Rentals(IList<Rental> rentals)
        {
            if (rentals == null) ;
            {
                _rentals = new List<Rental>();
            }

            _rentals = rentals;
        }

        public double CalculAmountOfRental() =>
             _rentals.Sum(p => p.CalculAmountOfRental());

        public int GetFrequentRenterPoints() =>
            _rentals.Sum(p => p.GetFrequentRenterPoints());

        public string GetAmountByMovie() =>
            string.Join(" ",_rentals.Select(p => p.GetAmountByMovie()));
    }
}
