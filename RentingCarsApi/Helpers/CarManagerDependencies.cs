using AutoMapper;
using RentingCarsApi.ControllerServices.Admin;
using RentingCarsApi.Data;

namespace RentingCarsApi.Helpers
{
    public interface ICarManagerDependencies
    {
        HttpRequest Request { get; }
        IPhotoFactory PhotoFactory { get; }
        ICatchCarExceptions CatchCarExceptions { get; }
        RentingDbContext Context { get; }
        IMapper Mapper { get; }
    }

    public class CarManagerDependencies : ICarManagerDependencies
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoFactory _photoFactory;
        private readonly ICatchCarExceptions _catchCarExceptions;
        private readonly RentingDbContext _context;
        private readonly IMapper _mapper;

        public CarManagerDependencies(
            IHttpContextAccessor httpContextAccessor,
            IPhotoFactory photoFactory,
            ICatchCarExceptions catchCarExceptions,
            RentingDbContext context,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _photoFactory = photoFactory;
            _catchCarExceptions = catchCarExceptions;
            _context = context;
            _mapper = mapper;
        }

        public HttpRequest Request => _httpContextAccessor.HttpContext.Request;
        public IPhotoFactory PhotoFactory => _photoFactory;
        public ICatchCarExceptions CatchCarExceptions => _catchCarExceptions;
        public RentingDbContext Context => _context;
        public IMapper Mapper => _mapper;
    }
}
