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
    public partial class ArtistDetail_Page : System.Web.UI.Page
    {
        public static Customer cust;

        private void DisplayView(int artistId)
        {
            List<Album> album = AlbumRepository.GetAlbumByArtistId(artistId);

            cardRepeaterAlbum.DataSource = album;
            cardRepeaterAlbum.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null && Request.Cookies["customer_cookie"] == null)
            {
                Response.Redirect("~/View/Login_Page.aspx");
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
            //if (CustomerController.checkUser())
            //{
            //    insertBtn.Visible = true;
            //}
            //else
            //{
            //    insertBtn.Visible = false;
            //}

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }

            int artistId = Convert.ToInt32(Request.QueryString["id"]);

            Artist art = ArtistRepository.GetArtistById(artistId);

            imageArtist.ImageUrl = "~/Assets/Artists/"+art.ArtistImage;

            nameArtist.Text = art.ArtistName + " Album's";

            if (!IsPostBack)
            {
                DisplayView(artistId);
            }

            if (!cust.CustomerRole.Equals("Admin") || cust == null)
            {
                foreach(RepeaterItem rpt in cardRepeaterAlbum.Items)
                {
                    Button updateBtn = (Button)rpt.FindControl("updateAlbumBtn");
                    updateBtn.Visible = false;

                    Button deleteBtn = (Button)rpt.FindControl("deleteAlbumBtn");
                    deleteBtn.Visible = false;
                }

                insertBtn.Visible = false;
            }
        }

        protected void cardRepeaterAlbum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (CustomerController.checkUser())
            {
                (e.Item.FindControl("updateAlbumBtn") as Control).Visible = true;
                
                (e.Item.FindControl("deleteAlbumBtn") as Control).Visible = true;
            }
            else
            {
                (e.Item.FindControl("updateAlbumBtn") as Control).Visible = false;
                (e.Item.FindControl("deleteAlbumBtn") as Control).Visible = false;
            }
        }

        protected void updateAlbumBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int albumId = Convert.ToInt32(button.CommandArgument.ToString());

            Album alb = AlbumHandler.GetAlbumById(albumId);

            if(alb == null)
            {
                HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
            }
            else
            {
                Response.Redirect("~/View/UpdateAlbum_Page.aspx?id=" + albumId);
            }

        }

        protected void deleteAlbumBtn_Click(object sender, EventArgs e)
        {
            int artistId = Int32.Parse(Request.QueryString["id"]);
            Button button = (Button)sender;
            int albumId = Int32.Parse(button.CommandArgument);
            string pathFile = Server.MapPath("~/Assets/Albums/");

            AlbumController.DeleteAlbum(albumId, pathFile);

            DisplayView(artistId);
        }

        protected void viewAlbumBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int albumId = Convert.ToInt32(button.CommandArgument.ToString());
            Response.Redirect("~/View/AlbumDetail_Page.aspx?id=" + albumId);
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            int artistId = Convert.ToInt32(Request.QueryString["id"]);

            Response.Redirect("~/View/InsertAlbum_Page.aspx?id=" + artistId);
        }
    }
}