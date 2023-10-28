using Project_PSD_Lab_Group5.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Project_PSD_Lab_Group5.Repository;

namespace Project_PSD_Lab_Group5.View
{
    public partial class UpdateArtist_Page : System.Web.UI.Page
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

            if(Request.QueryString["id"] == null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }

            if (!IsPostBack)
            {
                int artistId = Convert.ToInt32(Request.QueryString["id"]);
                Artist artist = ArtistRepository.GetArtistById(artistId);
                artistImage.ImageUrl = "~/Assets/Artists/" + artist.ArtistImage;
                artistName.Text = artist.ArtistName;
                txtName.Text = artist.ArtistName;
            }
        }

        protected void insertArtistBtn_Click(object sender, EventArgs e)
        {
            int artistId = Convert.ToInt32(Request.QueryString["id"]);
            Artist art = ArtistRepository.GetArtistById(artistId);

            string artistName = txtName.Text;

            if (ArtistController.InsertArtist(artistName, imageUpload).Equals(""))
            {
                ArtistController.UpdateArtist(artistId, artistName, imageUpload);
            }

            lblError.Text = ArtistController.InsertArtist(artistName, imageUpload);
        }
    }
}