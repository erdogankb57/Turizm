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
                   CreateMap<HotelDto, Hotel>()
                  .ForMember(dest => dest.Id, src => src.MapFrom(a => a.Id))
                  .ForMember(dest => dest.Name, src => src.MapFrom(a => a.Name))
                  .ForMember(dest => dest.Explanation, src => src.MapFrom(a => a.Explanation))
                  .ForMember(dest => dest.Adress, src => src.MapFrom(a => a.Adress))
                  .ForMember(dest => dest.Phone, src => src.MapFrom(a => a.Phone))
                  .ForMember(dest => dest.Logo, src => src.MapFrom(a => a.Logo))
                  .ForMember(dest => dest.RecordDate, src => src.MapFrom(a => a.RecordDate))
                  .ForMember(dest => dest.IsActive, src => src.MapFrom(a => a.IsActive))
                  .ForMember(dest => dest.HotelImages, src => src.MapFrom(a => a.HotelImages.Select(n => new HotelImage
                  {
                      Image = n.Image,
                      RecordDate = n.RecordDate,
                      Name = n.Name,
                      IsActive = n.IsActive,
                      HotelId = n.HotelId,
                      Id = n.Id
                  })))
                  .ForMember(dest => dest.HotelRooms, src => src.MapFrom(a => a.HotelRooms.Select(n => new HotelRoom
                  {
                      Explanation = n.Explanation,
                      HotelId = n.HotelId,
                      Id = n.Id,
                      IsActive = n.IsActive,
                      Name = n.Name,
                      NumberOfPeople = n.NumberOfPeople,
                      RecordDate = n.RecordDate,
                      HotelRoomImages = n.HotelRoomImages.Select(s => new HotelRoomImage
                      {
                          RecordDate = s.RecordDate,
                          HotelRoomlId = s.HotelRoomlId,
                          Image = s.Image,
                          Id = s.Id,
                          IsActive = s.IsActive,
                          Name = s.Name
                      }).ToList()
                  })));

                  CreateMap<Hotel, HotelDto>()
                  .ForMember(dest => dest.Id, src => src.MapFrom(a => a.Id))
                  .ForMember(dest => dest.Name, src => src.MapFrom(a => a.Name))
                  .ForMember(dest => dest.Explanation, src => src.MapFrom(a => a.Explanation))
                  .ForMember(dest => dest.Adress, src => src.MapFrom(a => a.Adress))
                  .ForMember(dest => dest.Phone, src => src.MapFrom(a => a.Phone))
                  .ForMember(dest => dest.Logo, src => src.MapFrom(a => a.Logo))
                  .ForMember(dest => dest.RecordDate, src => src.MapFrom(a => a.RecordDate))
                  .ForMember(dest => dest.IsActive, src => src.MapFrom(a => a.IsActive))
                  .ForMember(dest => dest.HotelImages, src => src.MapFrom(a => a.HotelImages.Select(n => new HotelImageDto
                  {
                      Image = n.Image,
                      RecordDate = n.RecordDate,
                      Name = n.Name,
                      IsActive = n.IsActive,
                      HotelId = n.HotelId,
                      Id = n.Id
                  })))
                  .ForMember(dest => dest.HotelRooms, src => src.MapFrom(a => a.HotelRooms.Select(n => new HotelRoomDto
                  {
                      Explanation = n.Explanation,
                      HotelId = n.HotelId,
                      Id = n.Id,
                      IsActive = n.IsActive,
                      Name = n.Name,
                      NumberOfPeople = n.NumberOfPeople,
                      RecordDate = n.RecordDate,
                      HotelRoomImages = n.HotelRoomImages.Select(s => new HotelRoomImageDto
                      {
                          RecordDate = s.RecordDate,
                          HotelRoomlId = s.HotelRoomlId,
                          Image = s.Image,
                          Id = s.Id,
                          IsActive = s.IsActive,
                          Name = s.Name
                      }).ToList()
                  })));



            CreateMap<DataResult<Hotel>, DataResult<HotelDto>>()
               .ForMember(dest => dest.Data, src => src.MapFrom(s => new HotelDto
               {
                   Adress = s.Data.Adress,
                   Explanation = s.Data.Explanation,
                   Id = s.Data.Id,
                   IsActive = s.Data.IsActive,
                   Logo = s.Data.Phone,
                   Name = s.Data.Name,
                   Phone = s.Data.Phone,
                   RecordDate = s.Data.RecordDate,
                   HotelImages = s.Data.HotelImages.Select(n => new HotelImageDto
                   {
                       Image = n.Image,
                       RecordDate = n.RecordDate,
                       Name = n.Name,
                       IsActive = n.IsActive,
                       HotelId = n.HotelId,
                       Id = n.Id
                   }).ToList()
               }));



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
                        }).ToList(),
                        HotelRooms = s.HotelRooms.Select(n => new HotelRoomDto
                        {
                            Explanation = n.Explanation,
                            HotelId = n.HotelId,
                            Id = n.Id,
                            IsActive = n.IsActive,
                            Name = n.Name,
                            NumberOfPeople = n.NumberOfPeople,
                            RecordDate = n.RecordDate,
                            HotelRoomImages = n.HotelRoomImages.Select(s => new HotelRoomImageDto
                            {
                                RecordDate = s.RecordDate,
                                HotelRoomlId = s.HotelRoomlId,
                                Image = s.Image,
                                Id = s.Id,
                                IsActive = s.IsActive,
                                Name = s.Name
                            }).ToList()
                        }).ToList()
                    }) : null
                    )
               ));

           

            











        }
    }
}
