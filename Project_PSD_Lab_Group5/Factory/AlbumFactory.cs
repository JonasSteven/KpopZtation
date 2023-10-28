using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Factory
{
    public class AlbumFactory
    {
        public static Album InsertAlbum(int id, string name, string desc, int price, int stock, string nameFile)
        {
            Album album = new Album();
            album.ArtistID = id;
            album.AlbumName = name;
            album.AlbumDescription = desc;
            album.AlbumPrice = price;
            album.AlbumStock = stock;
            album.AlbumImage = nameFile;

            return album;
        }
    }
}