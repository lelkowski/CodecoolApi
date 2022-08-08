using CodecoolApi.Services.Dtos.EducationalMaterial;
using CodecoolApi.Services.Dtos.EducationalMaterialReview;
using CodecoolApi.Services.Dtos.EducationalMaterialType;
using CodecoolApi.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodecoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _service;

        public TypeController(ITypeService service)
            => _service = service;


        [SwaggerOperation(Summary = "Returns All Types")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [SwaggerOperation(Summary = "Returns Specific Type")]
        [HttpGet("{id}", Name = "GetTypeAsync")]
        public async Task<IActionResult> GetTypeAsync(int id)
            => Ok(await _service.GetAsync(id));


        [SwaggerOperation(Summary = "Returns Educational Materials From Specific Type")]
        [HttpGet("{id}/materials", Name = "GetMaterialsFromSpecificTypeAsync")]
        public async Task<IActionResult> GetMaterialsFromSpecificTypeAsync(int id)
            => Ok(await _service.GetMaterialsFromSpecificTypeAsync(id));

        [SwaggerOperation(Summary = "Creates New Type")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CreateUpdateTypeDto dto)
        {
            var newType = await _service.CreateNewAsync(dto);
            return CreatedAtRoute(nameof(GetTypeAsync), new { id = newType.Id }, newType);
        }

        [SwaggerOperation(Summary = "Delete Specific Type")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
