using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicRoom.Contracts.Request;
using MusicRoom.Contracts.Request.Queries;
using MusicRoom.Data;
using MusicRoom.Domain;
using MusicRoom.Domain.Filter;
using MusicRoom.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Services
{
    public class ArtistService : IArtistService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ArtistService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<bool> createArtistAsync(CreateArtistRequest artis)
        {
            var data_artis = _mapper.Map<Artists>(artis);
            await _dataContext.Artists.AddAsync(data_artis);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> deleteArtistAsync(long ArtistID)
        {
            var rm_artis = _dataContext.Artists.First(src => src.ArtistID == ArtistID);
            _dataContext.Artists.Remove(rm_artis);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<List<ArtistViewModel>> getAllArtistAsync(PaginationFilter paginationFilter = null)
        {
            //if(paginationFilter == null)
            //{
            //    var data_artists = await _dataContext.Artists.FromSqlRaw($"select ArtistID, ArtistName, AlbumName, ImageURL, ReleaseDate, Price, SampleURL from Artists").ToListAsync();
            //    var list_artist = _mapper.Map<List<ArtistViewModel>>(data_artists);

            //    return list_artist;
            //}

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            var data_artists2 = await _dataContext.Artists.FromSqlRaw($"select ArtistID, ArtistName, AlbumName, ImageURL, ReleaseDate, Price, SampleURL from Artists")
                    .Skip(skip).Take(paginationFilter.PageSize).ToListAsync();

            var list_artist2 = _mapper.Map<List<ArtistViewModel>>(data_artists2);

            return list_artist2;
        }

        public async Task<ArtistViewModel> getByIdAsync(long ArtistID)
        {
            var data_artist = await _dataContext.Artists.FromSqlRaw($"select ArtistID, ArtistName, AlbumName, ImageURL, ReleaseDate, Price, SampleURL from Artists where ArtistID={ArtistID}").SingleOrDefaultAsync();
            var data = _mapper.Map<ArtistViewModel>(data_artist);
            return data;
        }

        public async Task<bool> updateArtistAsync(long ArtistID, UpdateArtistRequest artis)
        {
            //inisialisasi ID
            artis.ArtistID = ArtistID;

            //mapping with mapper
            var data_artis = _mapper.Map<Artists>(artis);

            _dataContext.Artists.Update(data_artis);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
