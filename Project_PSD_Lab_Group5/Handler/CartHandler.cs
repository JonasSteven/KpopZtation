using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Handler
{
    public class CartHandler
    {
        public static void InsertToCart(int custId, int albumId, int qty)
        {
            CartRepository.InsertToCart(custId, albumId, qty);
        }

        public static void CheckOutCart(int custId)
        {

        //    var cart = CartRepository.GetAllOfCartItem(custId);

        //    int transHeaderId = TransactionRepository.AddToTransactionHeader(DateTime.Now, custId);

        //    foreach(Cart c in cart)
        //    {
        //        TransactionRepository.AddToTransactionDetail(transHeaderId, c.AlbumID, c.Qty);
        //    }

        //    AlbumRepository.UpdateStockOfAlbum(cart);

           CartRepository.CheckOutCart(custId);
        }
    }
}