using Project_PSD_Lab_Group5.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Controller
{
    public class TransactionController
    {
        public static dynamic GetTransactionHistory(Customer cust)
        {
            return TransactionHandler.GetTransactionHistory(cust);
        }
    }
}