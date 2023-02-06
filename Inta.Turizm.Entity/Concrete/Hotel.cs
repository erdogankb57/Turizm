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
        }

        public int Id { get; set; }
    }
}
