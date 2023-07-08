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
            var entities = await _Repository.GetAsync();

            return Ok(entities);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _Repository.GetAsync(id);

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VillaCreateDto dto)
        {
            _Repository.Insert(dto);

            await _Repository.SaveChangesAsync();

            return Ok(dto); 
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, VillaUpdateDto dto)
        {
            await _Repository.UpdateAsync(id, dto);

            await _Repository.SaveChangesAsync();

            return Ok(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _Repository.DeleteAsync(id);

            await _Repository.SaveChangesAsync();

            return NoContent();
        }

    }
}
