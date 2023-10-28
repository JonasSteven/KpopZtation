using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Factory
{
    public class CartFactory
    {
        public static Cart InsertToCart(int custId, int albumId, int qty)
        {
            Cart cart = new Cart();
            cart.CustomerID = custId;
            cart.AlbumID = albumId;
            cart.Qty = qty;

            return cart;
        }
    }
}