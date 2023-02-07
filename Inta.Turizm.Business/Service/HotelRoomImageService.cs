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
    public class HotelRoomImageImageService : IHotelRoomImageService
    {
        private IMapper _mapper;
        RepositoryBase<HotelRoomImage, DefaultDataContext>? manager;
        UnitOfWork<DefaultDataContext> unitOfWork;
        public HotelRoomImageImageService(IMapper mapper)
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<HotelRoomImage>();
            _mapper = mapper;
        }

        public DataResult<HotelRoomImageDto> Delete(int Id)
        {
            var entity = manager.Get(v => v.Id == Id).Data;
            var data = manager.Delete(entity);
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelRoomImageDto>>(data);
            return result;
        }

        public DataResult<List<HotelRoomImageDto>> Find(Expression<Func<HotelRoomImage, bool>>? filter, string[]? includes = null, int? skipNumber = null, int? takeNumber = null)
        {
            var data = manager.Find(filter, includes, skipNumber, takeNumber);
            var result = _mapper.Map<DataResult<List<HotelRoomImageDto>>>(data);
            return result;
        }

        public DataResult<HotelRoomImageDto> Get(Expression<Func<HotelRoomImage, bool>>? filter = null, string[]? includes = null)
        {
            var data = manager.Get(filter, includes);
            var result = _mapper.Map<DataResult<HotelRoomImageDto>>(data);
            return result;
        }

        public DataResult<HotelRoomImageDto> GetById(int id, string[]? includes = null)
        {
            var data = manager.GetById(1, includes);
            var result = _mapper.Map<DataResult<HotelRoomImageDto>>(data);
            return result;
        }

        public DataResult<HotelRoomImageDto> Save(HotelRoomImageDto dto)
        {
            var data = manager.Save(_mapper.Map<HotelRoomImageDto, HotelRoomImage>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelRoomImageDto>>(data);
            return result;
        }

        public DataResult<HotelRoomImageDto> Update(HotelRoomImageDto dto, string[]? updateFields = null)
        {
            var data = manager.Update(_mapper.Map<HotelRoomImageDto, HotelRoomImage>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelRoomImageDto>>(data);
            return result;
        }
    }
}
