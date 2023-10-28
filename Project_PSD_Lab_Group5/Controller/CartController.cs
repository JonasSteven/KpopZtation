using Project_PSD_Lab_Group5.Handler;
using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Controller
{
    public class CartController
    {
        public static string CheckInsertQty(int albumId, string qty)
        {
            string error = "";

            if (qty.Equals(""))
            {
                error = "Quantity must be filled";
                return error;
            }
            else if (!qty.Any(Char.IsDigit))
            {
                error = "Quantity must be number";
                return error;
            }
            else if (Int32.Parse(qty) == 0)
            {
                error = "Quantity can't be 0";
                return error;
            }
            else if (Int32.Parse(qty) > AlbumRepository.GetAlbumById(albumId).AlbumStock)
            {
                error = "Stock not enough";
                return error;
            }

            return error;
        }

        public static void InsertToCart(int custId, int albumId, int qty)
        {
            CartHandler.InsertToCart(custId, albumId, qty);
        }

        public static string CheckAlbumStock(int albumId, int qty)
        {
            Album alb = AlbumRepository.GetAlbumById(albumId);
            string error = "";

            if(qty > alb.AlbumStock)
            {
                error = alb.AlbumName + " album stock only " + alb.AlbumStock + " left";
                return error;
            }

            return error;
        }

        public static void CheckOutCart(int custId)
        {
            CartHandler.CheckOutCart(custId);
        }
    }
}