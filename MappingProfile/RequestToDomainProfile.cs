using AutoMapper;
using MusicRoom.Contracts.Request.Queries;
using MusicRoom.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.MappingProfile
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}
