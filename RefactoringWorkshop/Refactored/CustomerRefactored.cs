using RefactoringWorkshop.Refactored;
using System;
using System.Collections.Generic;

namespace RefactoringWorkshop
{

    public class CustomerRefactored : DomainObject
    {
        public IRental Rentals { get; init; }

        public string BaseStatement(IFormatter formatter)
        {
            double totalAmount = Rentals.CalculAmountOfRental();

            int frequentRenterPoints = Rentals.GetFrequentRenterPoints();

            string result = "Rental Record for " + Name + " ";

            result += Rentals.GetAmountByMovie();

            result = formatter.GetFooter(totalAmount, frequentRenterPoints, result);

            return result;
        }

        public string Statement() => BaseStatement(new BaseFormatter());

        public string HtmlStatement() => BaseStatement(new HtmlFormatter());


    }
}
