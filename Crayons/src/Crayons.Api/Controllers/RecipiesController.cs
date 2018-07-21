using System.Threading.Tasks;
using Crayons.Domain.Entities;
using Crayons.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crayons.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipiesController : Controller
    {
        private readonly IRecipiesService _recipiesService;

        public RecipiesController(IRecipiesService recipiesService)
        {
            _recipiesService = recipiesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_recipiesService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok ( _recipiesService.FindById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Recipe recipe)
        {
            _recipiesService.Add(recipe);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody]Recipe recipe)
        {
            _recipiesService.Update(recipe);
            return Ok();
        }
    }
}