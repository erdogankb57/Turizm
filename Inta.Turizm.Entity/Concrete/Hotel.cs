using Inta.Turizm.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Entity.Concrete
{
    [Table("Hotel")]
    public class Hotel : IEntity
    {
        public Hotel()
        {
			HotelImages = new List<HotelImage>();
        }

		[Key]
		[Column("Id")]
		public int Id { get; set; }
		
		[Column("Name")]
		public string? Name { get; set; }
		
		[Column("Explanation")]
		public string? Explanation { get; set; }
		
		[Column("Adress")]
		public string? Adress { get; set; }
		
		[Column("Phone")]
		public string? Phone { get; set; }
		
		[Column("Logo")]
		public string? Logo { get; set; }
		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }
	
		public bool IsActive { get; set; }

		virtual public  List<HotelImage> HotelImages { get; set; }
    }
}
