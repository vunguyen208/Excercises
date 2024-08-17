using AccountExercises.Object.Compare;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace AccountExercises.Object
{
    internal class AccountList
    {
        public ArrayList accountList;

        public AccountList()
        {
            accountList = new ArrayList();
        }
        public void NewAccount(Account account)
        {
            accountList.Add(account);

        }
        public bool CheckEmptyList()
        {
            return accountList.Count == 0;
        }
        public void SaveFile()
        {
            string path = "DataFile\\data.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {               
                foreach (Account acc in accountList)
                {
                    Account account = (Account)acc;
                    writer.WriteLine($"{account.ID},{account.FirstName},{account.LastName},{account.Balance}");
                }
            }
            string jsonPath = "DataFile\\jsonData.json";
            List<Account> accounts = new List<Account>();
            foreach (Account account in accountList)
            {
                accounts.Add(account);
            }
            string jsonString = JsonSerializer.Serialize(accounts, new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All) });
            File.WriteAllText(jsonPath, jsonString);
        }
        public void SortAccountListById()
        {
            accountList.Sort(new AccountId());
        }
        public void SortAccountListByFirstName()
        {
            accountList.Sort(new AccountFirstName());
        }
        public void SortAccountListByBalance()
        {
            accountList.Sort(new AccountBalance());
        }
        public void LoadFile()
        {
            accountList.Clear();
            string path = "DataFile\\data.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        int accountID = int.Parse(parts[0]);
                        string firstName = parts[1];
                        string lastName = parts[2];
                        int balance = int.Parse(parts[3]);

                        Account account = new Account(accountID, firstName, lastName, balance);
                        accountList.Add(account);
                    }
                }
            }
        }
        public void LoadJsonFile()
        {
            string path = "DataFile\\jsonData.json";
            string jsonString = File.ReadAllText(path);
            if(jsonString!="")
            {
                accountList.Clear();
                List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);
                foreach (Account account in accounts)
                {
                    accountList.Add(account);
                }
            }
        }
        public void Export()
        {
            Console.WriteLine("Danh sách các tài khoản :");
            for (int i = 0; i < accountList.Count; i++)
            {
                Account account = accountList[i] as Account;
                string name = account.FirstName + " " + account.LastName;
                Console.WriteLine($"-Tài khoản {i + 1,-4}  ID : {account.ID,-4}, Họ tên : {name,-20}, Số dư : {account.Balance,-20}");
            }
            Console.WriteLine();
        }
    }
}
