using System;
using System.Collections.Generic;

namespace RefactoringWorkshop
{

    public class Customer : DomainObject
    {
        public IList<Rental> Rentals = new List<Rental>();

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + " ";
            foreach (Rental item in Rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                switch (item.Tape.Movie.PriceCode)
                {
                    case Movie.Regular:
                        thisAmount += 2;
                        if (item.DaysRented > 2)
                            thisAmount += (item.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NewRelease:
                        thisAmount += item.DaysRented * 3;
                        break;
                    case Movie.Childrens:
                        thisAmount += 1.5;
                        if (item.DaysRented > 3)
                            thisAmount += (item.DaysRented - 3) * 1.5;
                        break;

                }
                totalAmount += thisAmount;

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((item.Tape.Movie.PriceCode == Movie.NewRelease) && item.DaysRented > 1) 
                    frequentRenterPoints++;

                //show figures for this rental
                result +=  item.Tape.Movie.Name  + thisAmount+ " ";

            }
            //add footer lines
            result += "Amount owed is " + totalAmount + " ";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}
