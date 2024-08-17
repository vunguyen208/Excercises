using BookExcercises.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExcercises.Action
{
    internal static class Input
    {
        public static void InputIntField(out int number, string request)
        {
            bool correctField;
            do
            {
                correctField = Int32.TryParse(Console.ReadLine(), out number);
                if (!correctField)
                {
                    Console.WriteLine(request);
                }
            }
            while (!correctField);
        }
        public static void InputSortWithField(BookList bookList)
        {
            Console.WriteLine("Bạn muốn sắp xếp danh theo trường nào?");
            Console.WriteLine("Nhập số tương ứng với trường bạn yêu cầu(1 : tên sách, 2 : tên tác giả, 3: nhà xuất bản, 4 : năm xuất bản)");
            int fieldIndex;
            do
            {
                InputIntField(out fieldIndex, "Nhập số là dạng số nguyên dương :");
                if (!(fieldIndex <= 4 && fieldIndex >= 1))
                {
                    Console.WriteLine("Số cần nhập phải là số trong khoảng từ 1 đến 4 :");
                }
            }
            while (!(fieldIndex <= 4 && fieldIndex >= 1));
            switch (fieldIndex)
            {
                case 1:
                    Output.DisplayBookListSortByName(bookList);
                    break;
                case 2:
                    Output.DisplayBookListSortByAuthor(bookList);
                    break;
                case 3:
                    Output.DisplayBookListSortByPublisher(bookList);
                    break;
                case 4:
                    Output.DisplayBookListSortByPublicationYear(bookList);
                    break;
            }
        }
        public static void InputBoolList(BookList bookList)
        {

            Console.WriteLine("Nhập vào số lượng sách:");
            int bookNumber;
            InputIntField(out bookNumber, "Mời nhập đúng giá trị số lượng sách là số tự nhiên :");

            for (int i = 0; i < bookNumber; i++)
            {
                Console.WriteLine($"Nhập vào thông tin cuốn sách số {i + 1} :");
                Console.Write("Tên :"); string name = Console.ReadLine();
                Console.Write("Tác giả :"); string author = Console.ReadLine();
                Console.Write("Nhà xuất bản :"); string publisher = Console.ReadLine();
                Console.Write("Năm xuất bản :");
                int publicationYear;
                InputIntField(out publicationYear, "Mời nhập đúng giá trị số năm sách là số tự nhiên :");
                Console.Write("Số hiệu ISBN :"); string iSBN = Console.ReadLine();
                Console.Write("Số chương :");
                int chapterNum;
                InputIntField(out chapterNum, "Mời nhập đúng giá trị số chương là số tự nhiên :");
                List<String> chapters = new List<String>();
                for (int j = 0; j < chapterNum; j++)
                {
                    Console.Write($"Nhập chương {j + 1} :");
                    string chapter = Console.ReadLine();
                    chapters.Add(chapter);
                }
                Book book = new Book(name, author, publisher, publicationYear, iSBN, chapters);
                bookList.Add(book);
                Console.WriteLine();
            }
        }
    }
}
