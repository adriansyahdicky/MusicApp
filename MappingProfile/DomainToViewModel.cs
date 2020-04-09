using AutoMapper;
using MusicRoom.Contracts.Request;
using MusicRoom.Domain;
using MusicRoom.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.MappingProfile
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Artists, ArtistViewModel>().
                ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(
                            src => src.ReleaseDate.ToString("yyyy-MM-dd")));

            CreateMap<ArtistViewModel, Artists>().
                ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => DateTime.Parse(src.ReleaseDate)));

            CreateMap<CreateArtistRequest, Artists>().
                ForMember(dest => dest.ReleaseDate , opt => opt.MapFrom(
                              src => DateTime.Parse(src.ReleaseDate))) 
                .ForMember(dest => dest.Price, opt=> opt.MapFrom(
                              src=> Convert.ToDecimal(src.Price)));

            CreateMap<UpdateArtistRequest, Artists>().
                ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(
                             src => DateTime.Parse(src.ReleaseDate)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(
                              src => Convert.ToDecimal(src.Price)));
        }
    }
}
