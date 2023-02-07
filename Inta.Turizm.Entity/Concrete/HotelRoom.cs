using Inta.Turizm.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Entity.Concrete
{
    [Table("HotelRoom")]
    public class HotelRoom : IEntity
    {
        public HotelRoom()
        {

        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Explanation { get; set; }
        public int? NumberOfPeople { get; set; }
        public DateTime? RecordDate { get; set; }
        public bool IsActive { get; set; }
        virtual public List<HotelRoomImage> HotelRoomImages { get; set; }
        virtual public Hotel CurrentHotel { get; set; }


    }
}
