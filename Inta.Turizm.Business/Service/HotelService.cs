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

        public DataResult<HotelDto> Delete(int Id)
        {
            var entity = manager.Get(v => v.Id == Id).Data;
            var data = manager.Delete(entity);
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelDto>>(data);
            return result;
        }

        public DataResult<List<HotelDto>> Find(Expression<Func<Hotel, bool>>? filter, string[]? includes = null, int? skipNumber = null, int? takeNumber = null)
        {
            var data = manager.Find(filter, includes,skipNumber,takeNumber); 
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
            var data = manager.GetById(1, includes);
            var result = _mapper.Map<DataResult<HotelDto>>(data);
            return result;
        }

        public DataResult<HotelDto> Save(HotelDto dto)
        {
            var data = manager.Save(_mapper.Map<HotelDto,Hotel>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelDto>>(data);
            return result;
        }

        public DataResult<HotelDto> Update(HotelDto dto, string[]? updateFields = null)
        {
            var data = manager.Update(_mapper.Map<HotelDto, Hotel>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelDto>>(data);
            return result;
        }
    }
}
