using Project_PSD_Lab_Group5.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Repository
{
    public class CartRepository
    {
        public static LocalDBEntities1 db = new LocalDBEntities1();
        public static Cart GetDetailCartCustomer(int custId, int albumId)
        {
            return (from ct in db.Carts where ct.CustomerID == custId && ct.AlbumID == albumId select ct).FirstOrDefault();
        }

        public static List<Cart> GetItemAllByCustId(int custId)
        {
            return (from cart in db.Carts where cart.CustomerID == custId select cart).ToList();
        }
        public static void InsertToCart(int custId, int albumId, int qty)
        {
            Cart cart = GetDetailCartCustomer(custId, albumId);

            if(cart == null)
            {
                db.Carts.Add(CartFactory.InsertToCart(custId, albumId, qty));
            }
            else
            {
                cart.Qty = cart.Qty + qty;
            }

            db.SaveChanges();
        }

        public static Cart GetCartItemById(int custid)
        {
            return (from c in db.Carts where c.CustomerID == custid select c).FirstOrDefault();
        }

        public static dynamic GetAllOfCartItem(int customId)
        {
            return db.Carts.Join(
                db.Albums, ct => ct.AlbumID, alb => alb.AlbumID,
                (ct, alb) => new
                {
                    CustomerID = ct.CustomerID,
                    AlbumID = alb.AlbumID,
                    AlbumName = alb.AlbumName,
                    AlbumImage = alb.AlbumImage,
                    AlbumPrice = alb.AlbumPrice,
                    Qty = ct.Qty
                
                }
                ).Where(cust => cust.CustomerID == customId).ToList();
        }

        public static void RemoveItem(int custId)
        {
            Cart cart = GetCartItemById(custId);
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void CheckOutCart(int custId)
        {
            while (GetCartItemById(custId) != null)
            {
                Cart removeCart = GetCartItemById(custId);
                Album alb = AlbumRepository.GetAlbumById(removeCart.AlbumID);

                AlbumRepository.UpdateStockOfAlbum(alb.AlbumID, removeCart.Qty);

                db.Carts.Remove(removeCart);
                db.SaveChanges();
            }
        }
    }
}