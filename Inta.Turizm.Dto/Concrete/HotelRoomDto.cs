using Inta.Turizm.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Dto.Concrete
{
    public class HotelRoomDto : IDto
    {
        public HotelRoomDto()
        {
            HotelRoomImages = new List<HotelRoomImageDto>();
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Explanation { get; set; }
        public int? NumberOfPeople { get; set; }
        public DateTime? RecordDate { get; set; }
        public bool IsActive { get; set; }
        virtual public List<HotelRoomImageDto> HotelRoomImages { get; set; }


    }
}
