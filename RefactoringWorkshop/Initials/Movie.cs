using System;
using System.Collections.Generic;

namespace RefactoringWorkshop
{
    public class Movie : DomainObject
    {
        public const int Childrens = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;
        public int PriceCode { get; set; }

    }
}
