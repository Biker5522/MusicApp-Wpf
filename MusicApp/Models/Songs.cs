using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Songs
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public string Band { get; set; }
        public int Year { get; set; }
        public string Album { get; set; }
    }
}
