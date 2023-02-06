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
            CreateMap<Banner, BannerDto>();

            CreateMap<BannerDto, Banner>();
            CreateMap<DataResult<IList<Banner>>, DataResult<List<BannerDto>>>();
            CreateMap<DataResult<List<BannerDto>>, DataResult<IList<Banner>>>();
            CreateMap<Expression<Func<Banner, bool>>, Expression<Func<BannerDto, bool>>>();
            CreateMap<Expression<Func<BannerDto, bool>>, Expression<Func<Banner, bool>>>();

        }
    }
}
