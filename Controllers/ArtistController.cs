using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicRoom.Contracts;
using MusicRoom.Contracts.Request;
using MusicRoom.Contracts.Request.Queries;
using MusicRoom.Contracts.Response;
using MusicRoom.Domain;
using MusicRoom.Domain.Filter;
using MusicRoom.Domain.ViewModel;
using MusicRoom.Helpers;
using MusicRoom.Services;

namespace MusicRoom.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ArtistController(IArtistService artistService, IMapper mapper, IUserService userService)
        {
            _artistService = artistService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet(ApiRoutes.Artist.GetAllArtist)]
        public async Task<IActionResult> GetAll([FromQuery]PaginationQuery paginationQuery)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery);
            var artists = await _artistService.getAllArtistAsync(paginationFilter);
            
            if(paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return Ok(new PagedResponse<ArtistViewModel>(artists));
            }
            //dicky
            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_userService, paginationFilter, artists);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoutes.Artist.GetByArtist)]
        public async Task<IActionResult> Get([FromRoute] Int64 ArtistID)
        {
            var artis = await _artistService.getByIdAsync(ArtistID);

            if (artis == null)
                return NotFound(new ResponseData<string>
                {
                    status = 404,
                    localTime = DateTime.Now,
                    data = "Data Dengan ID " + ArtistID + " Tidak Ada di Database"
                });

            return Ok(new ResponseData<ArtistViewModel>
            {
                data = artis,
                status = 200,
                localTime = DateTime.Now,
            });
        }

        [HttpPost(ApiRoutes.Artist.CreateArtist)]
        public async Task<IActionResult> Create([FromBody] CreateArtistRequest request)
        {

            var created = await _artistService.createArtistAsync(request);

            if (created)
                return Ok(new ResponseData<string>
                {
                    status = 200,
                    localTime = DateTime.Now,
                    data = "Data Berhasil Disimpan"
                });

            return BadRequest(new ResponseData<string>
            {
                status = 500,
                localTime = DateTime.Now,
                data = "Data Gagal Disimpan"
            });
        }

        [HttpPut(ApiRoutes.Artist.UpdateArtist)]
        public async Task<IActionResult> Update([FromRoute] Int64 ArtistID, [FromBody] UpdateArtistRequest request)
        {
            var update = await _artistService.updateArtistAsync(ArtistID, request);

            if (update)
                return Ok(new ResponseData<string> { 
                    status = 200,
                    localTime = DateTime.Now,
                    data = "Data Berhasil Diupdate"
                });

            return BadRequest(new ResponseData<string>
            {
                status = 500,
                localTime = DateTime.Now,
                data = "Data Gagal Diupdate"
            });
        }

        [HttpDelete(ApiRoutes.Artist.DeleteArtist)]
        public async Task<IActionResult> Delete([FromRoute] Int64 ArtistID)
        {
            var artis = await _artistService.deleteArtistAsync(ArtistID);

            if (artis)
                return Ok(new ResponseData<string>
                {
                    data = "Data Berhasil Dihapus",
                    status = 200,
                    localTime = DateTime.Now,
                });

            return BadRequest(new ResponseData<string>
            {
                status = 500,
                localTime = DateTime.Now,
                data = "Data Gagal Dihapus"
            });
        }

    }
}