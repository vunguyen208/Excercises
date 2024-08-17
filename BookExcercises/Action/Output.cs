using BookExcercises.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExcercises.Action
{
    internal static class Output
    {
        public static void DisplayBookList(BookList bookList)
        {
            List<Book> books = bookList.books;
            Console.WriteLine($"Tổng số sách là : {books.Count} ");
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                Console.WriteLine($"Cuốn sách số {i + 1} :");
                Console.WriteLine($"Tiêu đề : {book.Title}");
                Console.WriteLine($"Tác giả : {book.Author}");
                Console.WriteLine($"Nhà xuất bản : {book.Publisher}");
                Console.WriteLine($"Năm xuất bản : {book.PublicationYear}");
                Console.WriteLine($"Mã ISBN : {book.ISBN}");
                Console.WriteLine($"Các chương : ");
                int chaperNum = 0;
                foreach (string chaper in book.Chapters)
                {
                    chaperNum++;
                    Console.WriteLine($"Chương {chaperNum} : {chaper}");
                }
                Console.WriteLine();
            }
        }
        public static void DisplayBookListNoSort(BookList bookList)
        {
            Console.WriteLine("Danh sách các cuốn sách : ");
            DisplayBookList(bookList);
        }
        public static void DisplayBookListSort(BookList bookList)
        {
            bookList.Sort();
            Console.WriteLine("Sắp xếp danh sách các cuốn sách theo thứ tự tác giả, tên sách, năm xuất bản :");
            DisplayBookList(bookList);
        }
        public static void DisplayBookListSortByName(BookList bookList)
        {
            bookList.SortByName();
            Console.WriteLine("Sắp xếp danh sách các cuốn sách theo thứ tự tiêu đề :");
            DisplayBookList(bookList);
        }
        public static void DisplayBookListSortByAuthor(BookList bookList)
        {
            bookList.SortByAuthor();
            Console.WriteLine("Sắp xếp danh sách các cuốn sách theo thứ tự tên tác giả :");
            DisplayBookList(bookList);
        }
        public static void DisplayBookListSortByPublisher(BookList bookList)
        {
            bookList.SortByPublisher();
            Console.WriteLine("Sắp xếp danh sách các cuốn sách theo thứ tự nhà xuất bản :");
            DisplayBookList(bookList);
        }
        public static void DisplayBookListSortByPublicationYear(BookList bookList)
        {
            bookList.SortByPublicationYear();
            Console.WriteLine("Sắp xếp danh sách các cuốn sách theo thứ tự năm xuất bản :");
            DisplayBookList(bookList);
        }
    }
}
