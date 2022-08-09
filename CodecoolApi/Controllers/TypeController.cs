namespace CodecoolApi.Controllers
{
    /// <response code="401">Unauthenticated user can't use this endpoint</response>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _service;

        public TypeController(ITypeService service)
            => _service = service;

        /// <response code="200">Returned all reviews</response>
        [SwaggerOperation(Summary = "Returns All Types")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        /// <param name="id">Id of review</param>
        /// <response code="200">Returned selected type</response>
        [SwaggerOperation(Summary = "Returns Specific Type")]
        [HttpGet("{id}", Name = "GetTypeAsync")]
        public async Task<IActionResult> GetTypeAsync(int id)
            => Ok(await _service.GetAsync(id));


        /// <param name="id">Id of type</param>
        /// <response code="200">Returned all materials from specific type</response>
        /// <response code="404">Selected type was not found</response>
        [SwaggerOperation(Summary = "Returns Educational Materials From Specific Type")]
        [HttpGet("{id}/materials", Name = "GetMaterialsFromSpecificTypeAsync")]
        public async Task<IActionResult> GetMaterialsFromSpecificTypeAsync(int id)
            => Ok(await _service.GetMaterialsFromSpecificTypeAsync(id));

        /// <response code="201">Created type</response>
        /// <response code="403">Can't create type without permission</response>
        [SwaggerOperation(Summary = "Creates New Type")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CreateUpdateTypeDto dto)
        {
            var newType = await _service.CreateNewAsync(dto);
            return CreatedAtRoute(nameof(GetTypeAsync), new { id = newType.Id }, newType);
        }

        /// <param name="id">Id of review</param>
        /// <response code="204">Deleted selected type</response>
        /// <response code="403">Can't delete type without permission</response>
        /// <response code="404">Selected review was not found</response>
        [SwaggerOperation(Summary = "Delete Specific Type")]
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        /// <param name="id">Id of review</param>
        /// <response code="204">Updated selected type</response>
        /// <response code="403">Can't update type without permission</response>
        /// <response code="404">Selected type was not found</response>
        [SwaggerOperation(Summary = "Updates Specific Type")]
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReviewAsync(int id, CreateUpdateTypeDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
    }
}
