using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Dto.Concrete
{
    public class HotelImageDto
    {
		public int Id { get; set; }
		public int HotelId { get; set; }
		public string? Name { get; set; }
		public string? Image { get; set; }
		public DateTime? RecordDate { get; set; }
		public bool IsActive { get; set; }
		public HotelDto CurrentHotel { get; set; }

	}
}
