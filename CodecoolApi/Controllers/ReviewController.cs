using CodecoolApi.Services.Dtos.EducationalMaterial;
using CodecoolApi.Services.Dtos.EducationalMaterialReview;
using CodecoolApi.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodecoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
            => _service = service;

        /// <response code="200">Returned all reviews</response>
        [SwaggerOperation(Summary = "Returns All Reviews")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        /// <param name="id">Id of review</param>
        /// <response code="200">Returned selected review</response>
        /// <response code="404">Selected review was not found</response>
        [SwaggerOperation(Summary = "Returns Specific Review")]
        [HttpGet("{id}", Name = "GetReviewAsync")]
        public async Task<IActionResult> GetReviewAsync(int id)
            => Ok(await _service.GetAsync(id));

        /// <param name="id">Id of review</param>
        /// <response code="201">Created review</response>
        /// <response code="404">Can't create review, there is no educational material with that Id</response>
        [SwaggerOperation(Summary = "Creates New Review")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CreateUpdateReviewDto dto)
        {
            var newReview = await _service.CreateNewAsync(dto);
            return CreatedAtRoute(nameof(GetReviewAsync), new { id = newReview.Id }, newReview);
        }

        /// <param name="id">Id of review</param>
        /// <response code="204">Deleted selected review</response>
        /// <response code="404">Selected review was not found</response>
        [SwaggerOperation(Summary = "Delete Specific Review")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        /// <param name="id">Id of review</param>
        /// <response code="204">Updated selected review</response>
        /// <response code="404">Selected review was not found</response>
        [SwaggerOperation(Summary = "Updates Specific Review")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReviewAsync(int id, CreateUpdateReviewDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
    }
}
