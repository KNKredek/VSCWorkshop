using System.Collections.Generic;
using Crayons.Domain.Entities;

namespace Crayons.Infrastructure.Services.Interfaces
{
    public interface IRecipiesService
    {
        Recipe FindById(int id);
        IList<Recipe> GetAll();
        void Add(Recipe recipe);
        void Update(Recipe recipe);
        void Delete(Recipe recipe);
    }
}