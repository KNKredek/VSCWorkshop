using System.Collections.Generic;
using Crayons.Domain.DataAccess.Repositories.Interfaces;
using Crayons.Domain.Entities;
using Crayons.Infrastructure.Services.Interfaces;

namespace Crayons.Infrastructure.Services
{
    public class RecipiesService : IRecipiesService
    {
        private readonly IRepository<Recipe> _recipiesRepository;
        public RecipiesService(IRepository<Recipe> recipiesRepository)
        {
            _recipiesRepository = recipiesRepository;
        }
        public void Add(Recipe recipe)
        {
            _recipiesRepository.Add(recipe);
        }

        public void Delete(Recipe recipe)
        {
            _recipiesRepository.Delete(recipe);
        }

        public Recipe FindById(int id)
        {
            return _recipiesRepository.FindById(id);
        }

        public IList<Recipe> GetAll()
        {
            return _recipiesRepository.GetAll();
        }

        public void Update(Recipe recipe)
        {
            _recipiesRepository.Update(recipe);
        }
    }
}