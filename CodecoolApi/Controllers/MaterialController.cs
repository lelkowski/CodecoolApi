using CodecoolApi.Services.Dtos.EducationalMaterial;
using CodecoolApi.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodecoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
            => _service = service;


        [SwaggerOperation(Summary = "Returns All Materials")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [SwaggerOperation(Summary = "Returns All Materials With Reviews Above Average")]
        [HttpGet("average")]
        public async Task<IActionResult> GetAllWithReviewsAboveAverageAsync()
            => Ok(await _service.GetAllWithNestedDataWithReviewsAboveAverageAsync());


        [SwaggerOperation(Summary = "Returns Specific Material")]
        [HttpGet("{id}", Name = "GetMaterialAsync")]
        public async Task<IActionResult> GetAuthorAsync(int id)
            => Ok(await _service.GetAsync(id));

        [SwaggerOperation(Summary = "Returns All Materials With Reviews Above Average From Specific Author")]
        [HttpGet("{id}/average")]
        public async Task<IActionResult> GetAllWithReviewsAboveAverageFromSpecificAuthorAsync(int id)
            => Ok(await _service.GetAllWithNestedDataWithReviewsAboveAverageAsync(id));

        [SwaggerOperation(Summary = "Creates New Material")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CreateUpdateMaterialDto dto)
        {
            var newMaterial = await _service.CreateNewAsync(dto);
            return CreatedAtRoute(nameof(GetAuthorAsync), new { id = newMaterial.Id }, newMaterial);
        }

        [SwaggerOperation(Summary = "Delete Specific Material")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
