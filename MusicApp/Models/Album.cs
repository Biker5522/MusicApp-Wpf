using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MusicApp
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BandId { get; set; }
        public int Year { get; set; }
        public ImageSource Cover { get; set; }

        public Album(string title, string bandId, int year)
        {
            Id = 0;
            Title = title;
            BandId = bandId;
            Year = year;

        }

    }
}
