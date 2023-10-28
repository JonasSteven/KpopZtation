using Project_PSD_Lab_Group5.Controller;
using Project_PSD_Lab_Group5.Handler;
using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class TransactionHistory_Page : System.Web.UI.Page
    {
        public static Customer cust;

        private void UpdateShowData()
        {
            transactionGV.DataSource = TransactionRepository.GetTransactionHistory(cust);
            transactionGV.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["customer_cookie"] == null && Session["customer"] == null)
            {
                cust = null;
            }
            else
            {
                if (Session["customer"] == null)
                {
                    var customerId = Int32.Parse(Request.Cookies["customer_cookie"].Value);

                    cust = CustomerHandler.GetCustomerById(customerId);
                    Session["customer"] = cust;
                }
                else
                {
                    cust = (Customer)Session["customer"];
                }
            }

            if (!IsPostBack)
            {
                UpdateShowData();
            }
        }
    }
}