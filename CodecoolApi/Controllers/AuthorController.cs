using CodecoolApi.Services.Dtos.Author;
using CodecoolApi.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodecoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
            => _service = service;


        [SwaggerOperation(Summary = "Returns All Authors")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [SwaggerOperation(Summary = "Returns Specific Author")]
        [HttpGet("{id}", Name = "GetAuthorAsync")]
        public async Task<IActionResult> GetAuthorAsync(int id)
            => Ok(await _service.GetAsync(id));

        [SwaggerOperation(Summary = "Returns Most Productive Author")]
        [HttpGet("mostProductive", Name = "GetMostProductiveAuthorAsync")]
        public async Task<IActionResult> GetMostProductiveAuthorAsync()
            => Ok(await _service.GetMostProductiveAuthorAsync());


        [SwaggerOperation(Summary = "Creates New Author")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CreateUpdateAuthorDto dto)
        {
            var newAuthor = await _service.CreateNewAsync(dto);
            return CreatedAtRoute(nameof(GetAuthorAsync), new { id = newAuthor.Id }, newAuthor);
        }

        [SwaggerOperation(Summary = "Delete Specific Author")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Updates Specific Author")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, CreateUpdateAuthorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
    }
}
