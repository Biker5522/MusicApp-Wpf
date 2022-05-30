using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DTOs
{
    public class AlbumDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BandId { get; set; }
        public int Year { get; set; }
    }
}
