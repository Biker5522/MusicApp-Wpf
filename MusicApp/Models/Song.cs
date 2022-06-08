using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Song
    {
        public string Name { get; set; }
        public string BandId { get; set; }
        public int Year { get; set; }
        public string AlbumId { get; set; }
        public string GenreId { get; set; }
        public Song(string name, int year ,string bandId,string albumId, string genreId)
        {
            Name = name;
            Year = year;
            BandId = bandId;
            GenreId = genreId;
            AlbumId = albumId;

        }

       
    }
}
