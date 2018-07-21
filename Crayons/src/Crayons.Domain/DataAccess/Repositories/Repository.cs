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
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}