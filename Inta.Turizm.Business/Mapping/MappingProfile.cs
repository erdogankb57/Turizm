using AutoMapper;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Concrete;
using Inta.Turizm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelDto>();

            CreateMap<HotelDto, Hotel>();
            CreateMap<DataResult<IList<Hotel>>, DataResult<List<HotelDto>>>();
            CreateMap<DataResult<List<HotelDto>>, DataResult<IList<Hotel>>>();
            CreateMap<Expression<Func<Hotel, bool>>, Expression<Func<HotelDto, bool>>>();
            CreateMap<Expression<Func<HotelDto, bool>>, Expression<Func<Hotel, bool>>>();

        }
    }
}
