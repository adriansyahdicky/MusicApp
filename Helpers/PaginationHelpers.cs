using MusicRoom.Contracts.Request.Queries;
using MusicRoom.Contracts.Response;
using MusicRoom.Domain.Filter;
using MusicRoom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Helpers
{
    public class PaginationHelpers
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(IUserService uriService, PaginationFilter paginationFilter, List<T> listResponse)
        {
            var nextPage = paginationFilter.PageNumber > 1 ?
                      uriService.GetAllUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() :
                      null;

            var prevoiousPage = paginationFilter.PageNumber - 1 > 1 ?
                      uriService.GetAllUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() :
                      null;

            return new PagedResponse<T>
            {
                Data = listResponse,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null,
                NextPage = listResponse.Any() ? nextPage : null,
                PreviousPage = prevoiousPage
            };

        }
    }
}
