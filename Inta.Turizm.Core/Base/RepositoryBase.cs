using Inta.Turizm.Core.Abstract;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Logging.Log;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inta.Turizm.Core.Base
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity, TContext> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        private readonly DbContext? _dbContext = null;
        public RepositoryBase(DbContext? dbContext = null)
        {
            if (_dbContext == null)
                _dbContext = dbContext;
        }
        public DataResult<TEntity> Delete(TEntity Entity)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {
                if (_dbContext != null)
                {
                    var deletedEntity = _dbContext.Entry(Entity);
                    deletedEntity.State = EntityState.Deleted;
                    result.ResultType = MessageTypeResult.Success;
                    result.Data = Entity;
                }
            }
            catch (Exception ex)
            {
                result.Data = default(TEntity);
                result.ResultType = MessageTypeResult.Error;

                LogManager.InsertLog(ex, this.GetType().Name + " base repository delete", Entity);

            }

            return result;
        }

        public DataResult<TEntity> Get(Expression<Func<TEntity, bool>>? filter, string[]? includes = null)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {
                if (_dbContext != null)
                {
                    if (filter != null)
                    {
                        var data = _dbContext.Set<TEntity>();

                        if (includes != null)
                        {
                            foreach (var item in includes)
                                result.Data = _dbContext.Set<TEntity>().Include(item).AsNoTracking().SingleOrDefault(filter);
                        }
                        else
                            result.Data = _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefault(filter);

                    }
                    result.ResultType = MessageTypeResult.Success;
                }
            }
            catch (Exception ex)
            {
                result.ResultType = MessageTypeResult.Error;
                result.Data = default(TEntity);
                result.ErrorMessage = ex.ToString();

                LogManager.InsertLog(ex, this.GetType().Name + " base repository get", filter);

            }
            return result;
        }

        public DataResult<TEntity> GetById(int id, string[]? includes = null)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();

            try
            {
                if (_dbContext != null)
                {
                    var data = _dbContext.Set<TEntity>().AsNoTracking();
                    if (includes != null)
                    {
                        foreach (var item in includes)
                            result.Data = data.Include(item).AsNoTracking().SingleOrDefault(s => s.Id == id);
                    }
                    else
                        result.Data = data.AsNoTracking().SingleOrDefault(s => s.Id == id);

                    //_dbContext.Entry<TEntity>(data).State = EntityState.Detached;
                    result.ResultType = MessageTypeResult.Success;
                }

            }
            catch (Exception ex)
            {
                result.Data = default(TEntity);
                result.ResultType = MessageTypeResult.Error;
                result.ErrorMessage = ex.ToString();

                LogManager.InsertLog(ex, this.GetType().Name + " base repository getById");

            }

            return result;
        }

        public DataResult<List<TEntity>> Find(Expression<Func<TEntity, bool>>? filter, string[]? includes = null, int? skipNumber = null, int? takeNumber = null)
        {
            DataResult<List<TEntity>> result = new DataResult<List<TEntity>>();
            try
            {
                if (_dbContext != null)
                {
                    if (filter == null)
                    {
                        IQueryable<TEntity> data = _dbContext.Set<TEntity>();

                        if (skipNumber != null)
                            data = data.Skip(skipNumber ?? 0);

                        if (takeNumber != null)
                            data = data.Take(takeNumber ?? 0);

                        if (includes?.Count() > 0)
                        {
                            foreach (var item in includes.Where(s => s.Trim() != string.Empty))
                                result.Data = data.Include(item).AsNoTracking().ToList();
                        }
                        else
                            result.Data = data.AsNoTracking().ToList();
                    }
                    else
                    {
                        IQueryable<TEntity> data = _dbContext.Set<TEntity>().AsNoTracking().Where(filter);

                        if (skipNumber != null)
                            data = data.Skip(skipNumber ?? 0);

                        if (takeNumber != null)
                            data = data.Take(takeNumber ?? 0);

                        if (includes?.Count() > 0)
                        {
                            foreach (var item in includes.Where(s => s.Trim() != string.Empty))
                                result.Data = data.Include(item).AsNoTracking().ToList();
                        }
                        else
                            result.Data = data.AsNoTracking().ToList();
                    }

                    result.ResultType = MessageTypeResult.Success;
                }
            }
            catch (Exception ex)
            {
                result.Data = default(List<TEntity>);
                result.ResultType = MessageTypeResult.Error;
                result.ErrorMessage = ex.ToString();

                LogManager.InsertLog(ex, this.GetType().Name + " base repository find", filter);

            }
            return result;
        }

        public DataResult<TEntity> Save(TEntity Entity)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {

                if (_dbContext != null)
                {

                    var addedEntity = _dbContext.Entry(Entity);
                    addedEntity.State = EntityState.Added;
                    //context.SaveChanges();
                }

                result.Data = Entity;
                result.ResultType = MessageTypeResult.Success;
            }
            catch (Exception ex)
            {
                result.Data = default(TEntity);
                result.ResultType = MessageTypeResult.Error;
                result.ErrorMessage = ex.ToString();

                LogManager.InsertLog(ex, this.GetType().Name + " base repository save", Entity);

            }

            return result;
        }

        public DataResult<TEntity> Update(TEntity Entity, string[]? updateFields = null)
        {
            DataResult<TEntity> result = new DataResult<TEntity>();
            try
            {
                if (_dbContext != null)
                {
                    var updatedEntity = _dbContext.Entry<TEntity>(Entity);
                    updatedEntity.State = EntityState.Modified;
                    if (updateFields != null && updateFields.Count() > 0)
                    {
                        foreach (var item in updatedEntity.Properties.Where(v => !updateFields.Any(a => a == v.Metadata.Name) && !v.Metadata.IsPrimaryKey()).ToList())
                            item.IsModified = false;
                    }


                }

                result.Data = Entity;
                result.ResultType = MessageTypeResult.Success;
            }
            catch (Exception ex)
            {
                result.Data = default(TEntity);
                result.ResultType = MessageTypeResult.Error;
                result.ErrorMessage = ex.ToString();

                LogManager.InsertLog(ex, this.GetType().Name + " base repository update", Entity);
            }

            return result;
        }
    }

}
