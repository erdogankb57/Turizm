using AutoMapper;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Concrete;
using Inta.Turizm.Entity.Concrete;
using System.Linq.Expressions;

namespace Inta.Turizm.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelDto>();

            CreateMap<HotelDto, Hotel>();
            CreateMap<DataResult<IList<Hotel>>, DataResult<List<HotelDto>>>();
            CreateMap<DataResult<List<Hotel>>, DataResult<List<HotelDto>>>();
            CreateMap<DataResult<List<HotelDto>>, DataResult<IList<Hotel>>>();
            CreateMap<DataResult<List<HotelDto>>, DataResult<List<Hotel>>>();
            CreateMap<Expression<Func<Hotel, bool>>, Expression<Func<HotelDto, bool>>>();
            CreateMap<Expression<Func<HotelDto, bool>>, Expression<Func<Hotel, bool>>>();


            CreateMap<HotelImageDto, HotelImage>();
            CreateMap<DataResult<IList<HotelImage>>, DataResult<List<HotelImageDto>>>();
            CreateMap<DataResult<List<HotelImage>>, DataResult<List<HotelImageDto>>>();
            CreateMap<DataResult<List<HotelImageDto>>, DataResult<IList<HotelImage>>>();
            CreateMap<DataResult<List<HotelImageDto>>, DataResult<List<HotelImage>>>();
            CreateMap<Expression<Func<HotelImage, bool>>, Expression<Func<HotelImageDto, bool>>>();
            CreateMap<Expression<Func<HotelImageDto, bool>>, Expression<Func<HotelImage, bool>>>();


        }
    }
}
