using Project_PSD_Lab_Group5.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Repository
{
    public class CustomerRepository
    {
        public static LocalDBEntities1 db = new LocalDBEntities1();

        public static string RegisCustomer(string name, string email, string gender, string address, string password, string roles)
        {
            Customer cust = CustomerFactory.RegisCustomer(name, email, gender, address, password, roles);
            db.Customers.Add(cust);
            db.SaveChanges();

            return "1";
        }

        public static Customer GetCustomerForLogin(string email, string password)
        {
            return (from c in db.Customers where email.Equals(c.CustomerEmail) && password.Equals(c.CustomerPassword) select c).FirstOrDefault();
        }

        public static Customer GetCustomerById(int customerId)
        {
            return (from c in db.Customers where c.CustomerID == customerId select c).FirstOrDefault();
        }

        public static bool EmailUniqueChecker(string email)
        {
            return (from c in db.Customers where c.CustomerEmail.Equals(email) select c).FirstOrDefault() == null;
        }

        public static string UpdateCustomer(int id, string name, string email, string gender, string address, string password, string role)
        {
            Customer cust = db.Customers.Find(id);
            cust.CustomerName = name;
            cust.CustomerEmail = email;
            cust.CustomerGender = gender;
            cust.CustomerAddress = address;
            cust.CustomerPassword = password;
            cust.CustomerRole = role;

            db.SaveChanges();

            return "1";
        }

        public static void UpdateProfileCustomer(int id, string name, string email, string gender, string address, string password, string roles)
        {
            Customer custom = GetCustomerById(id);

            custom.CustomerName = name;
            custom.CustomerEmail = email;
            custom.CustomerGender = gender;
            custom.CustomerAddress = address;
            custom.CustomerPassword = password;
            custom.CustomerRole = roles;

            db.SaveChanges();
        }

        public static string DeleteAccount(int custId)
        {
            Customer cust = GetCustomerById(custId);

            if(cust != null)
            {
                db.Customers.Remove(cust);
            }

            db.SaveChanges();

            return "1";
        }
    }
}