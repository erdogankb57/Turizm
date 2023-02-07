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
            CreateMap<DataResult<List<Hotel>>, DataResult<List<HotelDto>>>()
                .ForMember(dest =>
                dest.Data,
                act => act.MapFrom(
                    src => (src.Data != null ? src.Data.Select(s => new HotelDto
                    {
                        Adress = s.Adress,
                        Explanation = s.Explanation,
                        Id = s.Id,
                        IsActive = s.IsActive,
                        Logo = s.Phone,
                        Name = s.Name,
                        Phone = s.Phone,
                        RecordDate = s.RecordDate,
                        HotelImages = s.HotelImages.Select(n => new HotelImageDto
                        {
                            Image = n.Image,
                            RecordDate = n.RecordDate,
                            Name = n.Name,
                            IsActive = n.IsActive,
                            HotelId = n.HotelId,
                            Id = n.Id
                        }).ToList()
                    }) : null
                    )
               ));

        }
    }
}
