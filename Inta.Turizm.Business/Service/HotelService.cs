using AutoMapper;
using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Business.DataContext;
using Inta.Turizm.Core.Base;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Concrete;
using Inta.Turizm.Entity.Concrete;
using System.Linq.Expressions;

namespace Inta.Turizm.Business.Service
{
    public class HotelService : IHotelService
    {
        private IMapper _mapper;
        RepositoryBase<Hotel, DefaultDataContext>? manager;
        UnitOfWork<DefaultDataContext> unitOfWork;
        public HotelService(IMapper mapper)
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<Hotel>();
            _mapper = mapper;
        }

        public DataResult<HotelDto> Delete(HotelDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<HotelDto>> Find(Expression<Func<Hotel, bool>>? filter, string[]? includes = null)
        {
            var data = manager.Find(filter, includes); 
            var result = _mapper.Map<DataResult<List<HotelDto>>>(data);
            return result;
        }

        public DataResult<HotelDto> Get(Expression<Func<Hotel, bool>>? filter = null, string[]? includes = null)
        {
            var data = manager.Get(filter, includes);
            var result = _mapper.Map<DataResult<HotelDto>>(data);
            return result;
        }

        public DataResult<HotelDto> GetById(int id, string[]? includes = null)
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
