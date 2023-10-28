using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Factory
{
    public class CustomerFactory
    {
        public static Customer RegisCustomer(string name, string email, string gender, string address, string password, string roles)
        {
            Customer cust = new Customer();
            cust.CustomerName = name;
            cust.CustomerEmail = email;
            cust.CustomerGender = gender;
            cust.CustomerAddress = address;
            cust.CustomerPassword = password;
            cust.CustomerRole = roles;

            return cust;
        }
    }
}