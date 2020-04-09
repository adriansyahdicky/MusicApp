using Microsoft.AspNetCore.WebUtilities;
using MusicRoom.Contracts.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Services
{
    public class UriService : IUserService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllUri(PaginationQuery paginationQuery = null)
        {
            var uri = new Uri(_baseUri);

            if(paginationQuery == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", paginationQuery.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", paginationQuery.PageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}
