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
    public partial class Home_Page : System.Web.UI.Page
    {
        public static Customer cust;
        public void updateView()
        {
            cardRepeater.DataSource = ArtistRepository.GetAllofArtist();
            cardRepeater.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Customer cust;

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

            //if (Request.QueryString["id"] == null)
            //{
            //    Response.Redirect("~/view/Home_Page.aspx");
            //}

            //int artistId = Int32.Parse(Request.QueryString["id"]);
            //Artist art = ArtistRepository.GetArtistById(artistId);

            //homeImage.ImageUrl = "~/Assets/Artists/"+art.ArtistName;

            if (!IsPostBack)
            {
                updateView();
            }

            if (!cust.CustomerRole.Equals("Admin") || cust == null)
            {
                foreach (RepeaterItem item in cardRepeater.Items)
                {
                    Button deleteBtn = (Button)item.FindControl("deleteArtistBtn");
                    deleteBtn.Visible = false;

                    Button updateBtn = (Button)item.FindControl("updateArtistBtn");
                    updateBtn.Visible = false;
                }

                insertBtn.Visible = false;
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertArtist_Page.aspx");
        }

        protected void cardRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (CustomerController.checkUser())
            {
                (e.Item.FindControl("updateArtistBtn") as Control).Visible = true;
                (e.Item.FindControl("deleteArtistBtn") as Control).Visible = true;
            }
            else
            {
                (e.Item.FindControl("updateArtistBtn") as Control).Visible = false;
                (e.Item.FindControl("deleteArtistBtn") as Control).Visible = false;
            }
        }

        protected void updateArtistBtn_Click1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int artistId = Convert.ToInt32(button.CommandArgument.ToString());

            Artist art = ArtistHandler.GetArtistById(artistId);

            if(art == null)
            {
                HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
            }
            else
            {
                Response.Redirect("~/View/UpdateArtist_Page.aspx?id=" + artistId);
            }
        }

        protected void deleteArtistBtn_Click1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int artistId = Convert.ToInt32(button.CommandArgument.ToString());
            string pathFile = Server.MapPath("~/Assets/Artists/");
            ArtistController.DeleteArtist(artistId, pathFile);
            updateView();
        }

        protected void viewArtistBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int artistId = Convert.ToInt32(button.CommandArgument.ToString());
            Response.Redirect("~/View/ArtistDetail_Page.aspx?id="+artistId);
        }
    }
}