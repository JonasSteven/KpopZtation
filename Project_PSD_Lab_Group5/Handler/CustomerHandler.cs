using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Handler
{
    public class CustomerHandler
    {
        public static Customer GetCustomerForLogin(string email, string password)
        {
            return CustomerRepository.GetCustomerForLogin(email, password);
        }
        public static Customer GetCustomerById(int customerId)
        {
            return CustomerRepository.GetCustomerById(customerId);
        }

        public static string UpdateCustomer(int id, string name, string email, string gender, string address, string password, string role)
        {
            return CustomerRepository.UpdateCustomer(id, name, email, gender, address, password, role);
        }
    }
}