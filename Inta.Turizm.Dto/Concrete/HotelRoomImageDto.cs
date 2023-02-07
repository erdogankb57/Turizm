using Inta.Turizm.Dto.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Dto.Concrete
{
    public class HotelRoomImageDto:IDto
    {
        public HotelRoomImageDto()
        {
        }
        public int Id { get; set; }
        public int HoteRoomlId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? RecordDate { get; set; }
        public bool IsActive { get; set; }
    }
}
