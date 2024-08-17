using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExercises.Object
{
    internal class Account
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }
        public Account() { }
        public Account(int id)
        {
            this.ID = id;
        }
        public Account(int id, string firstName, string lastName, int balance)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Balance = balance;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Thông tin tài khoản :");
            Console.WriteLine($"ID : {ID}");
            Console.WriteLine($"Họ tên : {FirstName} {LastName}");
            Console.WriteLine($"Số dư : {Balance}");

        }

        public void InputInfo(int id)
        {
            Console.WriteLine("Đăng kí tài khoản,nhập thông tin tài khoản :");
            ID = id;
            Console.Write($"Họ : "); FirstName = Console.ReadLine();
            Console.Write($"Tên : "); LastName = Console.ReadLine();
            int balance;
            Console.Write($"Số dư : "); InputIntField(out balance, "Bạn cần nhập giá trị số tự nhiên");
            Balance = balance;
        }
        public void InputIntField(out int number, string request)
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

    }
}
