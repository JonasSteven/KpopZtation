using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Handler
{
    public class AlbumHandler
    {
        public static void InsertAlbum(int id, string name, string desc, int price, int stock, string nameFile)
        {
            AlbumRepository.InsertAlbum(id, name, desc, price, stock, nameFile);
        }

        public static Album GetAlbumById(int albumId)
        {
            return AlbumRepository.GetAlbumById(albumId);
        }

        public static void DeleteAlbum(int albumId)
        {
            AlbumRepository.DeleteAlbum(albumId);
        }

        public static void UpdateAlbum(int albumId, int artId, string name, string desc, int price, int stock, string nameFile)
        {
            AlbumRepository.UpdateAlbum(albumId, artId, name, desc, price, stock, nameFile);
        }
    }
}