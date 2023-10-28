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
    public partial class UpdateAlbum_Page : System.Web.UI.Page
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

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }

            if (!IsPostBack)
            {
                int albumId = Int32.Parse(Request.QueryString["id"]);
                Album alb = AlbumRepository.GetAlbumById(albumId);
                albumImage.ImageUrl = "~/Assets/Albums/" + alb.AlbumImage;
                lblAlbumName.Text = alb.AlbumName;
                lblAlbumDesc.Text = alb.AlbumDescription;
                lblAlbumPrice.Text = Convert.ToString(alb.AlbumPrice);
                lblAlbumStock.Text = Convert.ToString(alb.AlbumStock);

                txtName.Text = alb.AlbumName;
                txtDesc.Text = alb.AlbumDescription;
                txtPrice.Text = Convert.ToString(alb.AlbumPrice);
                txtStock.Text = Convert.ToString(alb.AlbumStock);
            }
        }

        protected void updateAlbumBtn_Click(object sender, EventArgs e)
        {
            int albumId = Int32.Parse(Request.QueryString["id"]);
            Album alb = AlbumRepository.GetAlbumById(albumId);

            string name = txtName.Text;
            string desc = txtDesc.Text;
            string price = txtPrice.Text;
            string stock = txtStock.Text;
            string artistId = Convert.ToString(alb.ArtistID);
            int artId = Int32.Parse(artistId);

            if (AlbumController.CheckInsertAlbum(name, desc, price, stock, imageUpload).Equals(""))
            {
                AlbumController.UpdateAlbum(albumId, artId, name, desc, Int32.Parse(price), Int32.Parse(stock), imageUpload);
            }

            lblError.Text = AlbumController.CheckInsertAlbum(name, desc, price, stock, imageUpload);
        }
    }
}