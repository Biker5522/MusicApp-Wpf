using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Band
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Band(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
}
