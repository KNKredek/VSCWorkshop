using System.Collections.Generic;
using System.Linq;
using Crayons.Domain.DataAccess.Repositories.Interfaces;
using Crayons.Domain.Entities;

namespace Crayons.Domain.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CrayonsDbContext _context;
        public Repository(CrayonsDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        public virtual T FindById(int id)
        {
            return _context.Set<T>().Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }

        public virtual IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            Save();
        }

        protected virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}