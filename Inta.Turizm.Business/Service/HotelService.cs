using AutoMapper;
using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Business.DataContext;
using Inta.Turizm.Core.Abstract;
using Inta.Turizm.Core.Base;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Abstract;
using Inta.Turizm.Dto.Concrete;
using Inta.Turizm.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Business.Service
{
    public class HotelService : IHotelService
    {
        private IMapper _mapper;
        RepositoryBase<Hotel, DefaultDataContext>? manager;
        UnitOfWork<DefaultDataContext> unitOfWork;
        public HotelService()
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<Hotel>();
        }

        public DataResult<HotelDto> Delete(HotelDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<HotelDto>> Find(Expression<Func<Hotel, bool>>? filter = null)
        {
            var data = manager.Find(filter);
            var result = _mapper.Map<DataResult<List<HotelDto>>>(data);
            return result;
        }

        public DataResult<HotelDto> Get(Expression<Func<Hotel, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public DataResult<HotelDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<HotelDto> Save(HotelDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResult<HotelDto> Update(HotelDto dto, string[]? updateFields = null)
        {
            throw new NotImplementedException();
        }
    }
}
