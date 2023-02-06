using Inta.Turizm.Core.Abstract;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Abstract;
using System.Linq.Expressions;

namespace Inta.Turizm.Business.Abstract
{
    public interface IBaseService<IDto, IEntity>
    {
        DataResult<IDto> GetById(int id);
        DataResult<List<IDto>> Find(Expression<Func<IEntity, bool>>? filter = null, Expression<Func<IEntity, object>>? includes = null);
        DataResult<IDto> Save(IDto dto);
        DataResult<IDto> Update(IDto dto, string[]? updateFields = null);
        DataResult<IDto> Delete(IDto dto);
        DataResult<IDto> Get(Expression<Func<IEntity, bool>>? filter = null);
    }
}
