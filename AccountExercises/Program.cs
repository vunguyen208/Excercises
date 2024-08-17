using AccountExercises.Object;
using AccountExercises.Object.Compare;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccountExercises
{
    internal class Program
    {
        public static AccountList accountList;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            accountList = new AccountList();
            //accountList.LoadFile();
            accountList.LoadJsonFile();
            Task();
        }
        public static void Task()
        {
            Console.WriteLine("Bạn muốn thực hiện hành động nào?");
            Console.WriteLine("(1 : Tạo tài khoản mới, 2 : Hiển thị danh sách các tài khoản, 3 : Xóa tài khoản , 4 : Thoát)");
            string indexString = Console.ReadLine();
            switch (indexString)
            {
                case "1":
                    CreateNewAccount();
                    break;
                case "2":
                    DisplayListAccount();
                    break;
                case "3":
                    DeleteAccount();
                    break;
                case "4":
                    break;
            }
        }
        public static void DisplayListAccount()
        {
            if (accountList.CheckEmptyList())
            {
                Console.WriteLine("Danh sách chưa có tài khoản nào, nhấn nút bất kì để trở về");
                Console.ReadLine();
                Task();
            }
            else
            {
                Console.WriteLine("Hiển thị danh sách được sắp xếp trường nào?\n (1 : Id, 2 : Tên , 3 : Số dư tài khoản)");
                string index;
                do
                {
                    index = Console.ReadLine();
                    if (!index.Equals("1") && !index.Equals("2") && !index.Equals("3"))
                    {
                        Console.WriteLine("Bạn cần nhập đúng giá trị là \"1\" hoặc \"2\" hoặc \"3\" :");
                    }
                }
                while (!index.Equals("1") && !index.Equals("2") && !index.Equals("3"));
                switch (index)
                {
                    case "1":
                        accountList.SortAccountListById();
                        accountList.Export();
                        break;
                    case "2":
                        accountList.SortAccountListByFirstName();
                        accountList.Export();
                        break;
                    case "3":
                        accountList.SortAccountListByBalance();
                        accountList.Export();
                        break;

                }
                Task();
            }
        }
        public static void DeleteAccount()
        {
            if (accountList.CheckEmptyList())
            {
                Console.WriteLine("Danh sách chưa có tài khoản nào, nhấn nút bất kì để trở về");
                Console.ReadLine();
                Task();
            }
            else
            {
                Console.WriteLine("Nhập id của tài khoản bạn muốn xóa :");
                accountList.SortAccountListById();
                ArrayList accounts = accountList.accountList;
                bool idBool;
                int id;
                int index;
                do
                {
                    idBool = Int32.TryParse(Console.ReadLine(), out id);
                    Account compareAccount = new Account(id);
                    index = accounts.BinarySearch(compareAccount, new AccountId());
                    if (!idBool || index < 0)
                    {
                        Console.WriteLine("Giá trị bạn nhập không đúng, lưu ý giá trị phải là số tự nhiên, vui lòng thử lại :");
                    }
                }
                while (!idBool || index < 0);
                Account account = accounts[index] as Account;
                account.DisplayInfo();
                Console.WriteLine("Bạn có muốn xóa tài khoản này không?(0 : có , 1 : không)");
                string indexString;
                InputStringToSelectTrueFalse(out indexString);
                if (indexString.Equals("0"))
                {
                    accounts.Remove(account);
                    accountList.accountList = accounts;
                    accountList.SaveFile();
                    Console.WriteLine("Đã xóa tài khoản");
                    Console.WriteLine();
                    Task();
                }
                if (indexString.Equals("1"))
                {
                    Console.WriteLine();
                    Task();
                }
            }
        }
        public static void CreateNewAccount()
        {
            Account account = new Account();
            int id;
            if (accountList.accountList.Count == 0)
            {
                id = 1;
            }
            else
            {
                accountList.SortAccountListById();
                Account lastAccount = accountList.accountList[accountList.accountList.Count - 1] as Account;
                id = lastAccount.ID + 1;
            }
            account.InputInfo(id);
            Console.WriteLine("Bạn đã nhập thông tin cho tài khoản mới, bạn muốn lưu lại không?(0 : có, 1 : không)");
            string indexString;
            InputStringToSelectTrueFalse(out indexString);
            if (indexString.Equals("0"))
            {
                accountList.NewAccount(account);
                accountList.SaveFile();
                Console.WriteLine("Đã đăng kí tài khoản mới");
                account.DisplayInfo();
                Console.WriteLine();
                Task();
            }
            if (indexString.Equals("1"))
            {
                Console.WriteLine();
                Task();
            }
        }
        public static void InputStringToSelectTrueFalse(out string indexString)
        {
            do
            {
                indexString = Console.ReadLine();
                if (!indexString.Equals("0") && !indexString.Equals("1"))
                {
                    Console.WriteLine("Bạn cần nhập đúng giá trị 0 hoặc 1");
                }
            }
            while (!indexString.Equals("0") && !indexString.Equals("1"));
        }
    }
}
