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
    public partial class AlbumDetail_Page : System.Web.UI.Page
    {
        public static Customer cust;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/View/Home_Page.aspx");
            }

            int albumId = Int32.Parse(Request.QueryString["id"]);
            Album alb = AlbumRepository.GetAlbumById(albumId);

            albumImage.ImageUrl = "~/Assets/Albums/" + alb.AlbumImage;
            lblName.Text = alb.AlbumName;
            lblDesc.Text = alb.AlbumDescription;
            lblPrice.Text = Convert.ToString(alb.AlbumPrice);
            lblStock.Text = Convert.ToString(alb.AlbumStock);

            if(Request.Cookies["customer_cookie"] == null && Session["customer"] == null)
            {
                cust = null;

                lblQty.Visible = false;
                txtQty.Visible = false;
                addCartBtn.Visible = false;
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

            if (cust != null && !CustomerController.CheckCustomerRole(cust.CustomerRole).Equals("Cust"))
            {
                lblQty.Visible = false;
                txtQty.Visible = false;
                addCartBtn.Visible = false;
            }
        }

        protected void addCartBtn_Click(object sender, EventArgs e)
        {
            int albumId = Int32.Parse(Request.QueryString["id"]);
            string qty = txtQty.Text;

            if (CartController.CheckInsertQty(albumId, qty).Equals(""))
            {
                CartController.InsertToCart(cust.CustomerID, albumId, Int32.Parse(qty));
                lblError.Text = "Add to Cart";
            }
            else
            {
                lblError.Text = CartController.CheckInsertQty(albumId, qty);
            }
        }
    }
}