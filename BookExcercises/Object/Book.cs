using BookExcercises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExcercises.Object
{
    internal class Book : IBook, IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public List<string> Chapters { get; set; }

        public int CompareTo(Book other)
        {
            return string.Compare(Title, other.Title, StringComparison.Ordinal);
        }
        public Book(string title, string author, string publisher, int publicationYear, string iSBN, List<string> chapters)
        {
            Title = title; Author = author; Publisher = publisher; PublicationYear = publicationYear; PublicationYear = publicationYear; ISBN = iSBN; Chapters = chapters;
        }
    }
}
