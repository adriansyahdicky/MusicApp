using MusicRoom.Contracts.Request;
using MusicRoom.Contracts.Request.Queries;
using MusicRoom.Domain;
using MusicRoom.Domain.Filter;
using MusicRoom.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Services
{
    public interface IArtistService
    {
        Task<List<ArtistViewModel>> getAllArtistAsync(PaginationFilter paginationFilter = null);
        Task<ArtistViewModel> getByIdAsync(Int64 ArtistID);
        Task<bool> createArtistAsync(CreateArtistRequest artis);
        Task<bool> updateArtistAsync(Int64 ArtistID, UpdateArtistRequest artis);
        Task<bool> deleteArtistAsync(Int64 ArtistID);
    }
}
