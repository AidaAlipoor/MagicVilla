using Business.Dtos.VillaDtos;
using Business.Repositories.VillaRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IVillaRepository _repository;
        public VillaAPIController(IVillaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var viewModels = await _repository.GetAsync();

            return Ok(new APIResponse { Result = viewModels });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var viewModel = await _repository.GetAsync(id);

            return Ok(new APIResponse { Result = viewModel });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VillaCreateDto dto)
        {
            _repository.Insert(dto);

            await _repository.SaveChangesAsync();

            return Ok(dto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] VillaUpdateDto dto)
        {
            await _repository.UpdateAsync(dto);

            await _repository.SaveChangesAsync();

            return Ok(new APIResponse { Result = dto });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            await _repository.SaveChangesAsync();

            return NoContent();
        }



        public class APIResponse
        {
            public HttpStatusCode StatusCode { get; set; }
            public bool IsSuccess { get; set; } = true;
            public List<string> ErrorMessage { get; set; }
            public object Result { get; set; }
        }
    }
}
