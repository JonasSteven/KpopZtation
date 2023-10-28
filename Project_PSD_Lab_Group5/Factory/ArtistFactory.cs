using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Factory
{
    public class ArtistFactory
    {
        public static Artist AddArtist(string name, string extensionFile)
        {
            Artist art = new Artist();
            art.ArtistName = name;
            art.ArtistImage = extensionFile;

            return art;
        }
    }
}