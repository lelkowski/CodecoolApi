using CodecoolApi.Services.Exceptions;
namespace CodecoolApi.Services.Services
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TypeDto> CreateNewAsync(CreateUpdateTypeDto dto)
        {
            var newType = _mapper.Map<EducationalMaterialType>(dto);
            _unitOfWork.Types.Add(newType);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<TypeDto>(newType);
        }

        public async Task DeleteAsync(int id)
        {
            var typeToDelete = await _unitOfWork.Types.GetAsync(id);
            if (typeToDelete is null)
                throw new ResourceNotFoundException($"Type with id {id} not found");

            _unitOfWork.Types.Delete(typeToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task<IEnumerable<TypeDto>> GetAllAsync()
        {
            var types = await _unitOfWork.Types.GetAllWithNestedDataAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(types);
        }

        public async Task<TypeDto> GetAsync(int id)
        {
            var type = await _unitOfWork.Types.GetWithNestedDataAsync(id);
            if (type is null)
                throw new ResourceNotFoundException($"Type with id {id} not found");
            return _mapper.Map<TypeDto>(type);
        }

        public async Task<IEnumerable<MaterialDto>> GetMaterialsFromSpecificTypeAsync(int id)
        {
            var type = await _unitOfWork.Types.GetWithNestedDataAsync(id);
            if (type is null)
                throw new ResourceNotFoundException($"Type with id {id} not found");
            return _mapper.Map<IEnumerable<MaterialDto>>(type.Materials);
        }
        public async Task UpdateAsync(int id, CreateUpdateTypeDto dto)
        {
            var type = await _unitOfWork.Types.GetAsync(id);
            if (type == null)
            {
                throw new ResourceNotFoundException($"Type with id {id} not found");
            }
            _mapper.Map(dto, type);
            _unitOfWork.Types.Update(type);
            await _unitOfWork.CompleteUnitAsync();
        }
    }
}
