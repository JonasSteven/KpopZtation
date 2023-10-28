using Project_PSD_Lab_Group5.Controller;
using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class UpdateProfile_Page : System.Web.UI.Page
    {
        private void DisplayUpdateData(Customer cs)
        {
            lblName.Text = cs.CustomerName;
            lblEmail.Text = cs.CustomerEmail;
            lblGender.Text = cs.CustomerGender;
            lblAddress.Text = cs.CustomerAddress;
            lblPassword.Text = cs.CustomerPassword;

            txtName.Text = cs.CustomerName;
            txtEmail.Text = cs.CustomerEmail;
            rbl_gender.SelectedValue = cs.CustomerGender;
            txtAddress.Text = cs.CustomerAddress;
            txtPassword.Text = cs.CustomerPassword;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer c = CustomerController.CustomerLoginStatus();

            if(c == null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }

            if (!IsPostBack)
            {
                if (c != null)
                {
                    DisplayUpdateData(c);
                }
                else
                {
                    lblError.Text = "Data not exist";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string password = txtPassword.Text;
            string gender = "";

            gender = rbl_gender.SelectedValue.ToString();

            Customer cust = CustomerController.CustomerLoginStatus();

            if (CustomerController.UpdateCustomer(name, email, gender, address, password, cust.CustomerRole).Equals(""))
            {
                CustomerController.UpdateProfileCustomer(cust.CustomerID, name, email, gender, address, password, cust.CustomerRole);

                Response.Redirect("~/View/Home_Page.aspx");
            }
            else
            {
                lblError.Text = CustomerController.UpdateCustomer(name, email, gender, address, password, cust.CustomerRole);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Customer cust = CustomerController.CustomerLoginStatus();

            if (CustomerController.DeleteAccount(cust.CustomerID).Equals("1"))
            {
                CustomerController.LogOutSession();
            }
        }
    }
}