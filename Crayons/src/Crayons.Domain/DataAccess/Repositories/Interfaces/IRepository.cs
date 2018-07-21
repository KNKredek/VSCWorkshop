using System.Collections.Generic;
using Crayons.Domain.Entities;

namespace Crayons.Domain.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T FindById(int id);
        IList<T> GetAll();
        void Add(T entity);
        void Update(T entity);
    }
}