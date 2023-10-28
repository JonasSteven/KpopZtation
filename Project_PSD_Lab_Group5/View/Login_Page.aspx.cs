using Project_PSD_Lab_Group5.Controller;
using Project_PSD_Lab_Group5.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class Login_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["customer"] != null || Request.Cookies["customer_cookie"] != null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            bool rememberMe = checkRemember.Checked;

            if (CustomerController.LoginCustomer(email, password).Equals("1"))
            {
                Customer cust = CustomerHandler.GetCustomerForLogin(email, password);
                if (cust == null)
                {
                    lblError.Text = "Customer account not found";
                }
                else
                {
                    Session["customer"] = cust;

                    if (rememberMe)
                    {
                        HttpCookie cookies = new HttpCookie("customer_cookie");
                        cookies.Value = cust.CustomerID.ToString();
                        cookies.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookies);
                    }

                    Response.Redirect("~/View/Home_Page.aspx");
                }
            }
            else
            {
                lblError.Text = CustomerController.LoginCustomer(email, password);
            }
        }

        protected void btnGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home_Page.aspx");
        }
    }
}