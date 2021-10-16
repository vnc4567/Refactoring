using RefactoringWorkshop.Refactored;
using System;
using System.Collections.Generic;

namespace RefactoringWorkshop
{

    public class CustomerRefactored : DomainObject
    {
        public IList<Rental> Rentals = new List<Rental>();

        public string BaseStatement(IFormatter formatter)
        {
            Rentals rentals = new Rentals(Rentals);

            double totalAmount = rentals.CalculAmountOfRental();

            int frequentRenterPoints = rentals.GetFrequentRenterPoints();

            string result = "Rental Record for " + Name + " ";

            result += rentals.GetAmountByMovie();

            result = formatter.GetFooter(totalAmount, frequentRenterPoints, result);

            return result;
        }

        public string Statement() => BaseStatement(new BaseFormatter());

        public string HtmlStatement() => BaseStatement(new HtmlFormatter());


    }
}
