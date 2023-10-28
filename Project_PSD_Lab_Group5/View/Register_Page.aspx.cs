using Project_PSD_Lab_Group5.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class Register_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null || Request.Cookies["customer_cookie"] != null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string password = txtPassword.Text;
            string roles = "Cust";
            string gender = "";

            gender = rbl_gender.SelectedValue.ToString();

            if (CustomerController.RegisCustomer(name, email, gender, address, password, roles).Equals("1"))
            {
                Response.Redirect("~/View/Login_Page.aspx");
            }
            else
            {
                lblError.Text = CustomerController.RegisCustomer(name, email, gender, address, password, roles);
            }
        }
    }
}