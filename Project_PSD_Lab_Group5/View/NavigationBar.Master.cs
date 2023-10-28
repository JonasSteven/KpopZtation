using Project_PSD_Lab_Group5.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class NavigationBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerController.checkCustomerStatus();

            if ((Boolean)Session["customer_status"])
            {
                if (CustomerController.checkUser())
                {
                    goToCartBtn.Visible = false;
                }
                else
                {
                    goToCartBtn.Visible = true;
                }

                goToHomeBtn.Visible = true;
                goToTransaction.Visible = true;
                goToProfileBtn.Visible = true;
                logOutBtn.Visible = true;
            }
            else
            {
                goToHomeBtn.Visible = true;
                goToLoginBtn.Visible = true;
                goToRegisterBtn.Visible = true;
                goToCartBtn.Visible = false;
                goToProfileBtn.Visible = false;
                goToTransaction.Visible = false;
                logOutBtn.Visible = false;
            }
        }

        protected void goToHomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home_Page.aspx");
        }

        protected void goToLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login_Page.aspx");
        }

        protected void goToRegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register_Page.aspx");
        }

        protected void goToProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/UpdateProfile_Page.aspx");
        }

        protected void goToCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Cart_Page.aspx");
        }

        protected void goToTransaction_Click(object sender, EventArgs e)
        {
            if (CustomerController.checkUser())
            {
                Response.Redirect("~/View/TransactionReport_Page.aspx");
            }
            else
            {
                Response.Redirect("~/View/TransactionHistory_Page.aspx");
            }
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            CustomerController.LogOutSession();

            HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
        }
    }
}