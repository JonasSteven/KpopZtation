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
    public partial class Cart_Page : System.Web.UI.Page
    {
        public static Customer cust;
        public static List<Cart> ct;
        public static List<Album> alb;

        private void UpdateShowData()
        {
            cartImageRepeater.DataSource = ct;
            cartImageRepeater.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart c;
            if (Request.Cookies["customer_cookie"] == null && Session["customer"] == null)
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

            c = CartRepository.GetCartItemById(cust.CustomerID);

            if(c == null)
            {
                checkoutBtn.Visible = false;
            }

            ct = CartRepository.GetItemAllByCustId(cust.CustomerID);
            

            if (!IsPostBack)
            {
                UpdateShowData();
            }
        }

        protected void cartImageRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void removeItemBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int custId = Int32.Parse(button.CommandArgument.ToString());

            CartRepository.RemoveItem(custId);

            ct = CartRepository.GetItemAllByCustId(cust.CustomerID);

            UpdateShowData();
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            foreach(Cart cart in ct)
            {
                if(!CartController.CheckAlbumStock(cart.AlbumID, Convert.ToInt32(cart.Qty)).Equals(""))
                {
                    lblError.Text = CartController.CheckAlbumStock(cart.AlbumID, Convert.ToInt32(cart.Qty));

                    return;
                }
            }

            int transHeader = TransactionRepository.AddToTransactionHeader(DateTime.Now, cust.CustomerID);

            Cart carts = CartRepository.GetCartItemById(cust.CustomerID);
            //alb = AlbumRepository.GetAllAlbum(carts.AlbumID);

            var crt = CartRepository.GetAllOfCartItem(cust.CustomerID);

            foreach (var cart in crt)
            {
                TransactionRepository.AddToTransactionDetail(transHeader, cart.AlbumID, cart.Qty);
            }

            CartController.CheckOutCart(cust.CustomerID);

            ct = CartRepository.GetItemAllByCustId(cust.CustomerID);

            UpdateShowData();

            HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
        }

        public static string GetAlbumImageById(int albumId)
        {
            return (AlbumRepository.GetAlbumById(albumId)).AlbumImage.ToString();
        }

        public static string GetAlbumNameById(int albumId)
        {
            return (AlbumRepository.GetAlbumById(albumId)).AlbumName.ToString();
        }

        public static string GetAlbumPriceById(int albumId)
        {
            return (AlbumRepository.GetAlbumById(albumId)).AlbumPrice.ToString();
        }


    }
}