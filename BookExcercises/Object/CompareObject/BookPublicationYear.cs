using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExcercises.Object.CompareObject
{
    internal class BookPublicationYear : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.PublicationYear.CompareTo(y.PublicationYear);
        }
    }
}
