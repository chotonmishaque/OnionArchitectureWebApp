using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnionArchitecture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }
        public int Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Add(entity);
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return -2;
            }
        }

        public int Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var result = entities.SingleOrDefault(e => e.Id == entity.Id);
                if (result == null)
                {
                    return -3;
                }

                _dbContext.Entry(result).CurrentValues.SetValues(entity);
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return -2;
            }
        }

        public int Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException("entity");
                }
                var result = entities.SingleOrDefault(e => e.Id == id);
                if (result == null)
                {
                    return -3;
                }
                entities.Remove(result);
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return -2;
            }
        }
    }
}
