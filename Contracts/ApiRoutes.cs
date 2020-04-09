using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Artist
        {
            public const string GetAllArtist = Base+"/artists";
            public const string GetByArtist = Base + "/artists/{ArtistID}";
            public const string CreateArtist = Base + "/artists";
            public const string UpdateArtist = Base + "/artists/{ArtistID}";
            public const string DeleteArtist = Base + "/artists/{ArtistID}";
        }
    }
}
