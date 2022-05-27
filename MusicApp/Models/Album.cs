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
        private int Id { get; set; }
        public string Name { get; set; }
        public string Band { get; set; }
        public int Year { get; set; }
        public ImageSource Cover { get; set; }

    }
}
