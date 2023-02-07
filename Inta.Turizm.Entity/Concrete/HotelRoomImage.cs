using Inta.Turizm.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Entity.Concrete
{
    [Table("HotelRoomImage")]
    public class HotelRoomImage : IEntity
    {
        public HotelRoomImage()
        {
            CurrentHotelRoom = new HotelRoom();
        }

        public int Id { get; set; }
        public int HoteRoomlId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? RecordDate { get; set; }
        public bool IsActive { get; set; }

        virtual public HotelRoom CurrentHotelRoom { get; set; }

    }
}
