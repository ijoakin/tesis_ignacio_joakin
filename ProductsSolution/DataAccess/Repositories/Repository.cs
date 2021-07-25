using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DbContext context;
        private DbSet<TEntity> DbSet;

        public Repository(ProductsDBContext _context)
        {
            context = _context;
            this.DbSet = this.context.Set<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            IQueryable<TEntity> query = this.DbSet;
            return query.ToList();
        }
        public async Task<IList<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = this.DbSet;
            return await query.ToListAsync();
        }

        public TEntity GetById(int id)
        {
            IQueryable<TEntity> query = this.DbSet;
            return query.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            IQueryable<TEntity> query = this.DbSet;
            return query;
        }

        public async Task<IQueryable<TEntity>> GetQueryAsync()
        {
            var query =await this.DbSet.ToListAsync();
            return query.AsQueryable();
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                this.DbSet.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = this.GetById(id);
                this.DbSet.Remove(entity);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Save(TEntity entity)
        {
            try
            {
                if (entity.Id != 0)
                {
                    //this.context.Entry(entity).State = EntityState.Detached;
                    //var e = this.DbSet.Where(x => x.Id == entity.Id).FirstOrDefault();
                    this.DbSet.Update(entity);
                }
                else
                    this.DbSet.Add(entity);
                
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
