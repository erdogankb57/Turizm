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
    public class HotelRoomService : IHotelRoomService
    {
        private IMapper _mapper;
        RepositoryBase<HotelRoom, DefaultDataContext>? manager;
        UnitOfWork<DefaultDataContext> unitOfWork;
        public HotelRoomService(IMapper mapper)
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<HotelRoom>();
            _mapper = mapper;
        }

        public DataResult<HotelRoomDto> Delete(int Id)
        {
            var entity = manager.Get(v => v.Id == Id).Data;
            var data = manager.Delete(entity);
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelRoomDto>>(data);
            return result;
        }

        public DataResult<List<HotelRoomDto>> Find(Expression<Func<HotelRoom, bool>>? filter, string[]? includes = null, int? skipNumber = null, int? takeNumber = null)
        {
            var data = manager.Find(filter, includes, skipNumber, takeNumber);
            var result = _mapper.Map<DataResult<List<HotelRoomDto>>>(data);
            return result;
        }

        public DataResult<HotelRoomDto> Get(Expression<Func<HotelRoom, bool>>? filter = null, string[]? includes = null)
        {
            var data = manager.Get(filter, includes);
            var result = _mapper.Map<DataResult<HotelRoomDto>>(data);
            return result;
        }

        public DataResult<HotelRoomDto> GetById(int id, string[]? includes = null)
        {
            var data = manager.GetById(1, includes);
            var result = _mapper.Map<DataResult<HotelRoomDto>>(data);
            return result;
        }

        public DataResult<HotelRoomDto> Save(HotelRoomDto dto)
        {
            var data = manager.Save(_mapper.Map<HotelRoomDto, HotelRoom>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelRoomDto>>(data);
            return result;
        }

        public DataResult<HotelRoomDto> Update(HotelRoomDto dto, string[]? updateFields = null)
        {
            var data = manager.Update(_mapper.Map<HotelRoomDto, HotelRoom>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelRoomDto>>(data);
            return result;
        }
    }
}
