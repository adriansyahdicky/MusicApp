using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Contracts.Request
{
    public class CreateArtistRequest
    {
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string ImageURL { get; set; }
        public string ReleaseDate { get; set; }
        public string Price { get; set; }
        public string SampleURL { get; set; }
    }
}
