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
    [Table("Banner")]
    public class Hotel : IEntity
    {
        public Hotel()
        {
        }

		[Key]
		[Column("Id")]
		public int Id { get; set; }
		[Column("SystemUserId")]
		public int? SystemUserId { get; set; }
		[Column("LanguageId")]
		public int? LanguageId { get; set; }
		[Column("BannerTypeId")]
		public int? BannerTypeId { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("Link")]
		public string? Link { get; set; }
		[Column("TargetId")]
		public int? TargetId { get; set; }
		[Column("ShortExplanation")]
		public string? ShortExplanation { get; set; }
		[Column("OrderNumber")]
		public int OrderNumber { get; set; }
		[Column("Image")]
		public string? Image { get; set; }
		public bool IsActive { get; set; }
	}
}
