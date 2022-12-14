namespace CodecoolApi.Controllers
{
    /// <response code="401">Unauthenticated user can't use this endpoint</response>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
            => _service = service;


        /// <response code="200">Returned all materials</response>
        [SwaggerOperation(Summary = "Returns All Materials")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [SwaggerOperation(Summary = "Returns All Materials With Reviews Above Average")]
        [HttpGet("above-average")]
        public async Task<IActionResult> GetAllWithReviewsAboveAverageAsync()
            => Ok(await _service.GetAllWithNestedDataWithReviewsAboveAverageAsync());

        /// <param name="id">Id of material</param>
        /// <response code="200">Returned selected material</response>
        /// <response code="404">Selected material was not found</response>
        [SwaggerOperation(Summary = "Returns Specific Material")]
        [HttpGet("{id}", Name = "GetMaterialAsync")]
        public async Task<IActionResult> GetAuthorAsync(int id)
            => Ok(await _service.GetAsync(id));


        /// <param name="id">Id of material</param>
        /// <response code="204">Updated selected material</response>
        /// <response code="403">Can't update material without permission</response>
        /// <response code="404">Selected material was not found</response>
        [SwaggerOperation(Summary = "Updates Specific Material")]
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialAsync(int id, CreateUpdateMaterialDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <param name="id">Id of author</param>
        /// <response code="204">Returned all materials from selected author</response>
        /// <response code="404">Selected author was not found</response>
        [SwaggerOperation(Summary = "Returns All Materials With Reviews Above Average From Specific Author")]
        [HttpGet("{id}/above-average")]
        public async Task<IActionResult> GetAllWithReviewsAboveAverageFromSpecificAuthorAsync(int id)
            => Ok(await _service.GetAllWithNestedDataWithReviewsAboveAverageAsync(id));

        /// <response code="201">Created new material</response>
        /// <response code="403">Can't create material without permission</response>
        /// <response code="404">Can't create material, no author or type with those Ids</response>
        [SwaggerOperation(Summary = "Creates New Material")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CreateUpdateMaterialDto dto)
        {
            var newMaterial = await _service.CreateNewAsync(dto);
            return CreatedAtRoute(nameof(GetAuthorAsync), new { id = newMaterial.Id }, newMaterial);
        }

        /// <param name="id">Id of material</param>
        /// <response code="204">Deleted selected material</response>
        /// <response code="403">Can't delete material without permission</response>
        /// <response code="404">Selected material was not found</response>
        [SwaggerOperation(Summary = "Delete Specific Material")]
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
