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
    [Table("HotelImage")]
    public class HotelImage : IEntity
    {
        public HotelImage()
        {
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("HotelId")]
        [ForeignKey("HotelId ")]
        public int HotelId { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Image")]
        public string? Image { get; set; }

        [Column("RecordDate")]
        public DateTime? RecordDate { get; set; }

        public bool IsActive { get; set; }
        virtual public Hotel CurrentHotel { get; set; }


    }
}
