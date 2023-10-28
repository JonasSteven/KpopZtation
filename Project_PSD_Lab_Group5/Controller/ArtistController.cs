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
    public class ArtistController
    {
        public static List<Artist> GetAllofArtist()
        {
            return ArtistHandler.GetAllofArtist();
        }

        public static void ArtistUpdate(int artistId)
        {
            Artist artist = ArtistHandler.GetArtistById(artistId);

            if (artist == null)
            {
                HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/View/UpdateArtist.aspx?id=" + artist.ArtistID);
            }
        }

        public static string ExtensionValidate(string extension, int size)
        {
            string[] requiredExtension = { ".png", ".jpg", ".jpeg", ".jfif" };

            int fileSize = 2;
            int maxSize = fileSize * 1024 * 1024;

            string validate = "";
            if (!requiredExtension.Contains(extension))
            {
                validate = "-1";
            }
            else if(size >= maxSize)
            {
                validate = "-2";
            }

            return validate;
        }

        public static string InsertArtist(string name, FileUpload imageUpload)
        {
            string error = "";
            if (name.Equals(""))
            {
                error = "Name must be filled";
                return error;
            }

            if (ArtistRepository.GetArtistByName(name) != null)
            {
                error = "Name already inserted (must be unique)";
                return error;
            }

            if (imageUpload.HasFile)
            {
                string extension = Path.GetExtension(imageUpload.FileName).ToLower();

                int size = imageUpload.FileBytes.Length;
                if (ExtensionValidate(extension, size).Equals("-1"))
                {
                    error = "File extension must be .png, .jpg, .jpeg, or .jfif";
                    return error;
                }
                else if (ExtensionValidate(extension, size).Equals("-2"))
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

        public static void AddArtist(string name, FileUpload imageUpload)
        {
            string extensionFile = imageUpload.FileName;
            string pathFile = HttpContext.Current.Server.MapPath("~/Assets/Artists/") + extensionFile;

            imageUpload.SaveAs(pathFile);
            ArtistHandler.AddArtist(name, extensionFile);

            HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
        }

        public static void DeleteArtist(int artistId, string pathFile)
        {
            Artist art = ArtistHandler.GetArtistById(artistId);

            string pathImageFile = pathFile + art.ArtistImage;

            if (File.Exists(pathImageFile))
            {
                File.Delete(pathImageFile);
            }

            ArtistHandler.DeleteArtist(art.ArtistID);
            HttpContext.Current.Response.Redirect("~/view/Home_Page.aspx");
        }

        public static void UpdateArtist(int artistId, string artistName, FileUpload imageUpload)
        {
            string nameFile = imageUpload.FileName;
            string pathFile = HttpContext.Current.Server.MapPath("~/Assets/Artists/") + nameFile;
            //if (File.Exists(pathFile))
            //{
            //    File.Delete(pathFile);
            //}

            pathFile = HttpContext.Current.Server.MapPath("~/Assets/Artists/") + nameFile;
            imageUpload.SaveAs(pathFile);

            ArtistHandler.UpdateArtist(artistId, artistName, nameFile);

            HttpContext.Current.Response.Redirect("~/View/Home_Page.aspx");
        }
    }
}