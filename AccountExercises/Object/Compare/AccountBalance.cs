using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExercises.Object.Compare
{
    internal class AccountBalance : IComparer
    {
        public int Compare(object x, object y)
        {
            Account account1 = x as Account;
            Account account2 = y as Account;
            return account1.Balance.CompareTo(account2.Balance);
        }

    }
}
