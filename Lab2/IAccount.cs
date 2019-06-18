using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    interface IAccount
    {
        int CurrentSum { get; } 
        void Put(int sum);
        void Withdraw(int sum); 
    }
}
