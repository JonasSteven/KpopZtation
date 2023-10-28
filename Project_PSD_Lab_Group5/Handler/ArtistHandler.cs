using Project_PSD_Lab_Group5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Handler
{
    public class ArtistHandler
    {
        public static List<Artist> GetAllofArtist()
        {
            return ArtistRepository.GetAllofArtist();
        }

        public static Artist GetArtistById(int artistId)
        {
            return ArtistRepository.GetArtistById(artistId);
        }

        public static Artist GetArtistByName(string name)
        {
            return ArtistRepository.GetArtistByName(name);
        }

        public static void AddArtist(string name, string extensionFile)
        {
            ArtistRepository.AddArtist(name, extensionFile);
        }

        public static void DeleteArtist(int artistId)
        {
            ArtistRepository.DeleteArtist(artistId);
        }

        public static void UpdateArtist(int artistId, string artistName, string imageUpload)
        {
            ArtistRepository.UpdateArtist(artistId, artistName, imageUpload);
        }
    }
}