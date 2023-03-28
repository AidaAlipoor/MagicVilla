using Business.Dtos;
using Business.Repositories.VillaRepository;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IVillaRepository _Repository;
        public VillaAPIController(IVillaRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _Repository.GetAllAsync();

            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]VillaCreateDto dto)
        {
            _Repository.Insert(dto);

            await _Repository.SaveChangesAsync();

            return Ok(dto);
        }
    }
}
