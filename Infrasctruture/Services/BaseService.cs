using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Munizoft.Identity.Infrastructure.Services
{
    public abstract class BaseService<TService>
    {
        protected readonly ILogger<TService> _logger;
        protected readonly IMapper _mapper;
        protected readonly Models.IdentityOptions _options;

        public BaseService(
            ILogger<TService> logger,
            IMapper mapper,
            IOptions<Models.IdentityOptions> options
            )
        {
            _logger = logger;
            _mapper = mapper;
            _options = options.Value;
        }
    }
}