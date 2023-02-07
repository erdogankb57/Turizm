using Inta.Turizm.Dto.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Inta.Turizm.Dto.Concrete
{
    public class HotelDto : IDto
    {
        public HotelDto()
        {
			this.HotelImages = new List<HotelImageDto>();
        }
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Explanation { get; set; }
		public string? Adress { get; set; }
		public string? Phone { get; set; }
		public string? Logo { get; set; }
		public DateTime? RecordDate { get; set; }
		public bool IsActive { get; set; }

		[FromBody]
		public virtual List<HotelImageDto> HotelImages { get; set; }
	}
}
