using DotnetBackend.Core.Entities.Abstracts;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBackend.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext db;
        private DbSet<T> entities;
        public Repository(AppDbContext db)
        {
            this.db = db;
            entities = db.Set<T>();
        }
        public string TableName
        {
            get
            {
                var entityType = db.Model.FindEntityType(typeof(T));
                //var schema = entityType.GetSchema();
                var tableName = entityType.GetTableName();
                return tableName;
            }
        }

        public Task<IEnumerable<T>> AllAsync => throw new NotImplementedException();

        public IEnumerable<T> GetAll()
        {
            return entities;
        }
        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return entities.Where(expression);
        }
        public async Task<T> GetById(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<T> GetSingleWhere(Expression<Func<T, bool>> expression)
        {
            return await entities.Where(expression).FirstOrDefaultAsync();
        }
        public async Task Insert(T entity, bool save = true)
        {
            if (entity == null) throw new ArgumentNullException("Entity cannot be null");
            entity.CreatedDate = DateTimeOffset.Now;
            await entities.AddAsync(entity);
            if (save)
                await db.SaveChangesAsync();
        }

        public async Task InsertRange(IEnumerable<T> entityList, bool save = true)
        {
            if (entityList == null) throw new ArgumentNullException("Entity list cannot be null");

            if (entityList.Count() > 0)
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                await entities.AddRangeAsync(entityList);
                db.ChangeTracker.DetectChanges();

                if (save)
                    await db.SaveChangesAsync();

                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public async Task InsertBulk(IEnumerable<T> entityList)
        {
            if (entityList == null) throw new ArgumentNullException("Entity list cannot be null");

            if (entityList.Count() > 0)
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                var count = entityList.Count();
                if (count < 500)
                {
                    await entities.AddRangeAsync(entityList);
                    await db.SaveChangesAsync();
                }
                else
                {
                    var batchSize = count > 1000 ? 1000 : 500;
                    await db.BulkInsertAsync<T>(entityList.ToList(), bulkConfig: new BulkConfig { BatchSize = batchSize });
                }


                db.ChangeTracker.DetectChanges();
                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public async Task InsertOrUpdateBulk(IEnumerable<T> entityList)
        {
            if (entityList == null) throw new ArgumentNullException("Entity list cannot be null");

            if (entityList.Count() > 0)
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;

                var batchSize = entityList.Count() > 1000 ? 1000 : 500;
                await db.BulkInsertOrUpdateAsync(entityList.ToList(), bulkConfig: new BulkConfig { BatchSize = batchSize, EnableShadowProperties = true });

                db.ChangeTracker.DetectChanges();
                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public async Task Update(T entity, bool save = true)
        {
            if (entity == null) throw new ArgumentNullException("Entity cannot be null");
            db.Update<T>(entity);
            if (save)
                await db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<T> entityList, bool save = true)
        {
            if (entityList == null) throw new ArgumentNullException("Entity list cannot be null");
            entityList.Select(u =>
            {
                return u;
            });
            db.ChangeTracker.AutoDetectChangesEnabled = false;

            db.UpdateRange(entityList);
            db.ChangeTracker.DetectChanges();
            if (save)
                await db.SaveChangesAsync();

            db.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public async Task UpdateBulk(IEnumerable<T> entityList)
        {
            if (entityList == null) throw new ArgumentNullException("Entity list cannot be null");
            entityList.Select(u =>
            {
                return u;
            });
            db.ChangeTracker.AutoDetectChangesEnabled = false;

            var batchSize = entityList.Count() > 1000 ? 1000 : 500;
            await db.BulkUpdateAsync(entityList.ToList(), bulkConfig: new BulkConfig { BatchSize = batchSize });

            db.ChangeTracker.DetectChanges();
            db.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public async Task Delete(long id, bool save = true)
        {
            T entity = await entities.FindAsync(id);
            if (entity == null)
                throw new ArgumentNullException($"Entity with id '{id}' does not exist");

            entities.Remove(entity);
            if (save)
                await db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<long> ids, bool save = true)
        {
            IEnumerable<T> entityList = entities.Where(e => ids.Contains(e.Id));
            if (entityList.Count() > 0)
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                entities.RemoveRange(entityList);
                db.ChangeTracker.DetectChanges();
                if (save)
                    await db.SaveChangesAsync();

                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }
        public async Task DeleteWhere(Expression<Func<T, bool>> expression, bool save = true)
        {
            IEnumerable<T> entityList = entities.Where(expression);
            if (entityList.Count() > 0)
            {
                entities.RemoveRange(entityList);
                if (save)
                    await db.SaveChangesAsync();
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await entities.AnyAsync(expression);
        }
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return entities.Any(expression);
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> expression)
        {
            return await entities.CountAsync(expression);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = entities;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetSingleAsync(object Key)
        {
            return await entities.FindAsync(Key);
        }
    }
}
