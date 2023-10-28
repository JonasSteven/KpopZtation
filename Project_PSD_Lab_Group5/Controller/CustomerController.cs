using Project_PSD_Lab_Group5.Handler;
using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Controller
{
    public class CustomerController
    {
        public static string RegisCustomer(string name, string email, string gender, string address, string password, string roles)
        {
            string error = "";
            if (name.Equals("") || (name.Length < 5 || name.Length > 50))
            {
                error = "Name must be filled and between 5 and 50 characters";
                return error;
            }

            if (email.Equals("") || !(email.EndsWith("@gmail.com")))
            {
                error = "Email must be filled and endswith @gmail.com";
                return error;
            }

            if (gender.Equals(""))
            {
                error = "Gender must be selected";
                return error;
            }

            if(address.Equals("") || !(address.EndsWith("Street")))
            {
                error = "Address must be filled and ends with ‘Street’";
                return error;
            }

            if(password.Equals("") || !(password.Any(Char.IsDigit) && password.Any(Char.IsLetter))){
                error = "Password must be filled and alphanumeric";
                return error;
            }

            return CustomerRepository.RegisCustomer(name, email, gender, address, password, roles);
        }

        public static string LoginCustomer(string email, string password)
        {
            string error = "";
            if(email.Equals("") || password.Equals(""))
            {
                error = "Email and Password must be filled";
                return error;
            }

            return "1";
        }

        public static bool checkCustomerLogin()
        {
            return HttpContext.Current.Session["customer"] != null;
        }

        public static void checkCustomerStatus()
        {
            if (checkCustomerLogin())
            {
                HttpContext.Current.Session["customer_status"] = true;
            }
            else
            {
                HttpContext.Current.Session["customer_status"] = false;
            }
        }

        public static bool checkUser()
        {
            Customer cust = new Customer();

            if(HttpContext.Current.Request.Cookies["customer_cookie"] != null)
            {
                cust = CustomerHandler.GetCustomerById(Convert.ToInt32(HttpContext.Current.Request.Cookies["customer_cookie"].Value));

                return cust != null && cust.CustomerRole.ToString().Equals("Admin");
            }
            else
            {
                cust = (Customer)HttpContext.Current.Session["customer"];
            }

            return cust != null && cust.CustomerRole.ToString().Equals("Admin");
        }

        public static void LogOutSession()
        {
            HttpContext.Current.Session.Remove("customer");

            string[] cookie = HttpContext.Current.Request.Cookies.AllKeys;

            foreach(string cookies in cookie)
            {
                HttpContext.Current.Response.Cookies[cookies].Expires = DateTime.Now.AddHours(-1);
            }
        }

        public static Customer CustomerLoginStatus()
        {
            return (Customer)HttpContext.Current.Session["customer"];
        }

        public static string UpdateCustomer(string name, string email, string gender, string address, string password, string role)
        {
            string error = "";
            if (name.Equals("") || (name.Length < 5 || name.Length > 50))
            {
                error = "Name must be filled and between 5 and 50 characters";
                return error;
            }

            if (email.Equals("") || !(email.EndsWith("@gmail.com")))
            {
                error = "Email must be filled and endswith @gmail.com";
                return error;
            }

            if(!CustomerRepository.EmailUniqueChecker(email))
            {
                error = "Email already inserted (unique)";
                return error;
            }

            if (gender.Equals(""))
            {
                error = "Gender must be selected";
                return error;
            }

            if (address.Equals("") || !(address.EndsWith("Street")))
            {
                error = "Address must be filled and ends with ‘Street’";
                return error;
            }

            if (password.Equals("") || !(password.Any(Char.IsDigit) && password.Any(Char.IsLetter)))
            {
                error = "Password must be filled and alphanumeric";
                return error;
            }

            return error;
        }

        public static void UpdateProfileCustomer(int id, string name, string email, string gender, string address, string password, string role)
        {
            string roles = role;

            CustomerRepository.UpdateProfileCustomer(id, name, email, gender, address, password, roles);
        }

        public static string CheckCustomerRole(string role)
        {
            if (role.Equals("Admin"))
            {
                return "Admin";
            }
            else if (role.Equals("Guest"))
            {
                return "Guest";
            }
            else if (role.Equals("Cust"))
            {
                return "Cust";
            }

            return "";
        }

        public static string DeleteAccount(int custId)
        {
            return CustomerRepository.DeleteAccount(custId);
        }
    }
}