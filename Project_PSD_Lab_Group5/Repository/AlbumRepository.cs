using Project_PSD_Lab_Group5.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Repository
{
    public class AlbumRepository
    {
        public static LocalDBEntities1 db = new LocalDBEntities1();

        public static void InsertAlbum(int id, string name, string desc, int price, int stock, string nameFile)
        {
            Album album = AlbumFactory.InsertAlbum(id, name, desc, price, stock, nameFile);
            db.Albums.Add(album);
            db.SaveChanges();
        }

        public static List<Album> GetAlbumByArtistId(int artistId)
        {
            return (from alb in db.Albums where alb.ArtistID == artistId select alb).ToList();
        }

        public static Album GetAlbumById(int albumId)
        {
            return (from alb in db.Albums where alb.AlbumID == albumId select alb).FirstOrDefault();
        }

        public static void UpdateStockOfAlbum(int albumId, int qty)
        {
                Album alb = GetAlbumById(albumId);

                if(alb != null)
                {
                    alb.AlbumStock = alb.AlbumStock - qty;
                }

            db.SaveChanges();
        }

        public static void DeleteAlbum(int albumId)
        {
            Album alb = GetAlbumById(albumId);
            db.Albums.Remove(alb);
            db.SaveChanges();
        }

        public static void UpdateAlbum(int albumId, int artId, string name, string desc, int price, int stock, string nameFile)
        {
            Album album = AlbumRepository.GetAlbumById(albumId);
            album.ArtistID = artId;
            album.AlbumName = name;
            album.AlbumDescription = desc;
            album.AlbumPrice = price;
            album.AlbumStock = stock;
            album.AlbumImage = nameFile;

            db.SaveChanges();
        }

        public static List<Album> GetAllAlbum(int albumId)
        {
            return (from alb in db.Albums where alb.AlbumID == albumId select alb).ToList();
        }
    }
}