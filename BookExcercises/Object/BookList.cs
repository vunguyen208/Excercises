using BookExcercises.Object.CompareObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExcercises.Object
{
    internal class BookList
    {
        public List<Book> books;
        public BookList()
        {
            books = new List<Book>();
        }
        public void Add(Book book)
        {
            books.Add(book);
        }
        public void Remove(Book book)
        {
            books.Remove(book);
        }
        public void Clear()
        {
            books.Clear();
        }
        public bool Contains(Book book)
        {
            return books.Contains(book);
        }
        public int IndexOf(Book book)
        {
            return books.IndexOf(book);
        }
        public void Sort()
        {
            SortByPublicationYear();
            SortByName();
            SortByAuthor();
        }
        public void SortByAuthor()
        {
            books.Sort(new BookAuthor());
        }
        public void SortByPublicationYear()
        {
            books.Sort(new BookPublicationYear());
        }
        public void SortByPublisher()
        {
            books.Sort(new BookPublisher());
        }
        public void SortByName()
        {
            books.Sort(new BookTitle());
        }
    }
}
