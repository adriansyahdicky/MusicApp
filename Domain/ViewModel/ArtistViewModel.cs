using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Domain.ViewModel
{
    public class ArtistViewModel
    {
        public Int64 ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string ImageURL { get; set; }
        public string ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string SampleURL { get; set; }
    }
}
