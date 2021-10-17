using System;
using System.Collections.Generic;

namespace RefactoringWorkshop
{
    public class Rental : DomainObject
    {
        public int DaysRented { get; set; }
        public Tape Tape { get; set; }
    }
}
