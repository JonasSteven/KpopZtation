using Project_PSD_Lab_Group5.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Repository
{
    public class ArtistRepository
    {
        public static LocalDBEntities1 db = new LocalDBEntities1();

        public static List<Artist> GetAllofArtist()
        {
            return db.Artists.ToList();
        }

        public static Artist GetArtistById(int artistId)
        {
            return (from art in db.Artists where art.ArtistID == artistId select art).FirstOrDefault();
        }

        public static Artist GetArtistByName(string name)
        {
            return (from art in db.Artists where art.ArtistName.Equals(name) select art).FirstOrDefault();
        }

        public static void AddArtist(string name, string extensionFile)
        {
            Artist art = ArtistFactory.AddArtist(name, extensionFile);
            db.Artists.Add(art);
            db.SaveChanges();
        }

        public static void DeleteArtist(int artistId)
        {
            Artist art = db.Artists.Find(artistId);
            db.Artists.Remove(art);
            db.SaveChanges();
        }

        public static void UpdateArtist(int artistId, string artistName, string imageUpload)
        {
            Artist art = GetArtistById(artistId);
            art.ArtistName = artistName;
            art.ArtistImage = imageUpload;

            db.SaveChanges();
        }
    }
}