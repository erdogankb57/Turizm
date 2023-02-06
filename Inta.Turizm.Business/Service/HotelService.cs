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
        RepositoryBase<Banner, DefaultDataContext>? manager;
        UnitOfWork<DefaultDataContext> unitOfWork;
        public HotelService()
        {
            unitOfWork = new UnitOfWork<DefaultDataContext>();
            manager = unitOfWork.AddRepository<Banner>();
        }

        public DataResult<BannerDto> Delete(BannerDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<BannerDto>> Find(Expression<Func<Banner, bool>>? filter = null)
        {
            var data = manager.Find(filter);
            var result = _mapper.Map<DataResult<List<BannerDto>>>(data);
            return result;
        }

        public DataResult<BannerDto> Get(Expression<Func<Banner, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public DataResult<BannerDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult<BannerDto> Save(BannerDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResult<BannerDto> Update(BannerDto dto, string[]? updateFields = null)
        {
            throw new NotImplementedException();
        }
    }
}
