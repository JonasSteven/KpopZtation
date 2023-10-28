using Project_PSD_Lab_Group5.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class InsertArtist_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["customer_cookie"] == null && Session["customer"] == null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }

            if (!CustomerController.checkUser())
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }
        }

        protected void insertArtistBtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            
            if (ArtistController.InsertArtist(name, imageUpload).Equals(""))
            {
                ArtistController.AddArtist(name, imageUpload);
            }

            lblError.Text = ArtistController.InsertArtist(name, imageUpload);
        }
    }
}