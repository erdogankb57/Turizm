using Inta.Turizm.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Core.Abstract
{
    public interface IRepositoryBase<TEntity, TContext> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        DataResult<TEntity> GetById(int id, string[]? includes = null);
        DataResult<TEntity> Get(Expression<Func<TEntity, bool>>? filter, string[]? includes = null);
        DataResult<TEntity> Update(TEntity Entity, string[]? updateFields = null);
        DataResult<TEntity> Save(TEntity Entity);
        DataResult<TEntity> Delete(TEntity Entity);
        public DataResult<List<TEntity>> Find(Expression<Func<TEntity, bool>>? filter, string[]? includes = null, int? skipNumber = null, int? takeNumber = null);
    }
}
