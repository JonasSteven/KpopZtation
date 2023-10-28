using Project_PSD_Lab_Group5.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class InsertAlbum_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["customer_cookie"] == null && Session["customer"] == null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }

            if (!CustomerController.checkUser())
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }
        }

        protected void addAlbumBtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string desc = txtDesc.Text;
            string price = txtPrice.Text;
            string stock = txtStock.Text;

            int id = Convert.ToInt32(Request.QueryString["id"]);

            if (AlbumController.CheckInsertAlbum(name, desc, price, stock, imageUpload).Equals(""))
            {
                AlbumController.InsertAlbum(id, name, desc, Convert.ToInt32(price), Convert.ToInt32(stock), imageUpload);
            }

            lblError.Text = AlbumController.CheckInsertAlbum(name, desc, price, stock, imageUpload);
        }
    }
}