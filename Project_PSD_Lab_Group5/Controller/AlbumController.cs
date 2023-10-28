using Project_PSD_Lab_Group5.Handler;
using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.Controller
{
    public class AlbumController
    {
        public static string CheckInsertAlbum(string name, string desc, string price, string stock, FileUpload imageUpload)
        {
            string error = "";

            if (name.Equals(""))
            {
                error = "Album name must be filled";
                return error;
            }
            else if (name.Length >= 50)
            {
                error = "Album name must be smaller than 50 characters";
                return error;
            }

            if (desc.Equals(""))
            {
                error = "Album description must me filled";
                return error;
            }
            else if (desc.Length >= 255)
            {
                error = "Album description must be smaller than 255 characters";
                return error;
            }

            if (price.Equals(""))
            {
                error = "Album price must be filled";
                return error;
            }
            else if (!price.Any(Char.IsDigit))
            {
                error = "Album price must be number";
                return error;
            }
            else if (Int32.Parse(price) < 100000 || Int32.Parse(price) > 1000000)
            {
                error = "Album price must between 100000 and 1000000";
                return error;
            }

            if (stock.Equals(""))
            {
                error = "Album stock must be filled";
                return error;
            }
            else if (!stock.Any(Char.IsDigit))
            {
                error = "Album stock must be number";
                return error;
            }
            else if (Int32.Parse(stock) < 1)
            {
                error = "Album stock must be more than 0";
                return error;
            }

            if (imageUpload.HasFile)
            {
                string extensionFile = Path.GetExtension(imageUpload.FileName).ToString().ToLower();

                int sizeFile = imageUpload.FileBytes.Length;

                string[] requiredExtension = { ".png", ".jpg", ".jpeg", ".jfif" };
                int bytes = 2;
                int maxSizeFile = bytes * 1024 * 1024;

                if (!requiredExtension.Contains(extensionFile))
                {
                    error = "File extension must be .png, .jpg, .jpeg, or .jfif";
                    return error;
                }
                else if (sizeFile >= maxSizeFile)
                {
                    error = "File size must be lower than 2MB";
                    return error;
                }
            }
            else
            {
                error = "File must be chosen";
            }

            return error;
        }

        public static void InsertAlbum(int id, string name, string desc, int price, int stock, FileUpload imageUpload)
        {
            string nameFile = imageUpload.FileName;
            string pathFile = HttpContext.Current.Server.MapPath("~/Assets/Albums/")+nameFile;
            imageUpload.SaveAs(pathFile);

            AlbumHandler.InsertAlbum(id, name, desc, price, stock, nameFile);

            HttpContext.Current.Response.Redirect("~/View/ArtistDetail_Page.aspx?id="+id);
        }

        public static void DeleteAlbum(int albumId, string pathFile)
        {
            Album alb = AlbumRepository.GetAlbumById(albumId);

            string pathImage = pathFile + alb.AlbumImage;

            if (File.Exists(pathImage))
            {
                File.Delete(pathImage);
            }

            AlbumHandler.DeleteAlbum(alb.AlbumID);

            HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
        }

        public static void UpdateAlbum(int albumId, int artId, string name, string desc, int price, int stock, FileUpload imageUpload)
        {
            string nameFile = imageUpload.FileName;
            string pathFile = HttpContext.Current.Server.MapPath("~/Assets/Albums/") + nameFile;
            imageUpload.SaveAs(pathFile);

            AlbumHandler.UpdateAlbum(albumId, artId, name, desc, price, stock, nameFile);

            HttpContext.Current.Response.Redirect("~/View/ArtistDetail_Page.aspx?id="+artId);
        }
    }
}