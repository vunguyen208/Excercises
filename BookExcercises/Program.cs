using BookExcercises.Action;
using BookExcercises.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExcercises
{
    internal class Program
    {
        public static BookList bookList;
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            bookList = new BookList();
            Input.InputBoolList(bookList);
            Output.DisplayBookList(bookList);
            Output.DisplayBookListSort(bookList);
            Input.InputSortWithField(bookList);
        }
    }
}
