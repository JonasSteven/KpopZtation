using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Handler
{
    public class TransactionHandler
    {
        public static dynamic GetTransactionHistory(Customer cust)
        {
            return TransactionRepository.GetTransactionHistory(cust);
        }

        public static List<TransactionHeader> GetTransaction()
        {
            return TransactionRepository.GetTransaction();
        }
    }
}