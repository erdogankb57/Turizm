using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Business.DataContext;
using Inta.Turizm.Core.Base;
using Inta.Turizm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Business.Service
{
    public class HotelService : IHotelService
    {
        RepositoryBase<Hotel, DefaultDataContext> manager;
        UnitOfWork<DefaultDataContext> unitOfWork;
        public HotelService()
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<Hotel>();
        }
    }
}
