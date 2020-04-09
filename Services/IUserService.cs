using MusicRoom.Contracts.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Services
{
    public interface IUserService
    {
        Uri GetAllUri(PaginationQuery paginationQuery = null);
    }
}
