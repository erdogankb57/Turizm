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
    public class HotelImageService : IHotelImageService
    {
        private IMapper _mapper;
        RepositoryBase<HotelImage, DefaultDataContext>? manager;
        UnitOfWork<DefaultDataContext> unitOfWork;
        public HotelImageService(IMapper mapper)
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<HotelImage>();
            _mapper = mapper;
        }

        public DataResult<HotelImageDto> Delete(int Id)
        {
            var entity = manager.Get(v => v.Id == Id).Data;
            var data = manager.Delete(entity);
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelImageDto>>(data);
            return result;
        }

        public DataResult<List<HotelImageDto>> Find(Expression<Func<HotelImage, bool>>? filter, string[]? includes = null, int? skipNumber = null, int? takeNumber = null)
        {
            var data = manager.Find(filter, includes, skipNumber, takeNumber);
            var result = _mapper.Map<DataResult<List<HotelImageDto>>>(data);
            return result;
        }

        public DataResult<HotelImageDto> Get(Expression<Func<HotelImage, bool>>? filter = null, string[]? includes = null)
        {
            var data = manager.Get(filter, includes);
            var result = _mapper.Map<DataResult<HotelImageDto>>(data);
            return result;
        }

        public DataResult<HotelImageDto> GetById(int id, string[]? includes = null)
        {
            var data = manager.GetById(1, includes);
            var result = _mapper.Map<DataResult<HotelImageDto>>(data);
            return result;
        }

        public DataResult<HotelImageDto> Save(HotelImageDto dto)
        {
            var data = manager.Save(_mapper.Map<HotelImageDto, HotelImage>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelImageDto>>(data);
            return result;
        }

        public DataResult<HotelImageDto> Update(HotelImageDto dto, string[]? updateFields = null)
        {
            var data = manager.Update(_mapper.Map<HotelImageDto, HotelImage>(dto));
            unitOfWork.SaveChanges();
            var result = _mapper.Map<DataResult<HotelImageDto>>(data);
            return result;
        }
    }
}
