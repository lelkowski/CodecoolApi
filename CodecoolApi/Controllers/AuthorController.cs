namespace CodecoolApi.Controllers
{
    /// <response code="401">Unauthenticated user can't use this endpoint</response>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
            => _service = service;


        /// <response code="200">Returned all authors</response>
        [SwaggerOperation(Summary = "Returns All Authors")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        /// <param name="id">Id of author</param>
        /// <response code="200">Returned selected author</response>
        /// <response code="404">Selected author was not found</response>
        [SwaggerOperation(Summary = "Returns Specific Author")]
        [HttpGet("{id}", Name = "GetAuthorAsync")]
        public async Task<IActionResult> GetAuthorAsync(int id)
            => Ok(await _service.GetAsync(id));


        /// <response code="200">Returned most productive author</response>
        /// <response code="404">There is no author</response>
        [SwaggerOperation(Summary = "Returns Most Productive Author")]
        [HttpGet("mostProductive", Name = "GetMostProductiveAuthorAsync")]
        public async Task<IActionResult> GetMostProductiveAuthorAsync()
            => Ok(await _service.GetMostProductiveAuthorAsync());


        /// <response code="201">Created author</response>
        /// <response code="403">Can't create author without permission</response>
        [SwaggerOperation(Summary = "Creates New Author")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewAsync(CreateUpdateAuthorDto dto)
        {
            var newAuthor = await _service.CreateNewAsync(dto);
            return CreatedAtRoute(nameof(GetAuthorAsync), new { id = newAuthor.Id }, newAuthor);
        }

        /// <param name="id">Id of author</param>
        /// <response code="204">Deleted selected author</response>
        /// <response code="403">Can't delete author without permission</response>
        /// <response code="404">Selected author was not found</response>
        [SwaggerOperation(Summary = "Delete Specific Author")]
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        /// <param name="id">Id of author</param>
        /// <response code="204">Updated selected author</response>
        /// <response code="403">Can't update author without permission</response>
        /// <response code="404">Selected author was not found</response>
        [SwaggerOperation(Summary = "Updates Specific Author")]
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, CreateUpdateAuthorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
    }
}
