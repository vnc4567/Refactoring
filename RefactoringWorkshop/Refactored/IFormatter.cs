namespace RefactoringWorkshop.Refactored
{
    public interface IFormatter
    {
        string GetFooter(double totalAmount, int frequentRenterPoints, string result);
        string GetHeader(double name);
    }

    public class BaseFormatter : IFormatter
    {
        public string GetFooter(double totalAmount, int frequentRenterPoints, string result)
        {
            result += "Amount owed is " + totalAmount + " ";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        public string GetHeader(double name) => "Rental Record for " + name + " ";
    }

    public class HtmlFormatter : IFormatter
    {
        public string GetFooter(double totalAmount, int frequentRenterPoints, string result)
        {
            result += "<p>Amount owed is " + totalAmount + "<p><br>";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        public string GetHeader(double name)
        {
            throw new System.NotImplementedException();
        }
    }
}
