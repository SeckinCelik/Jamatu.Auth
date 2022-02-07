using AutoMapper;

namespace Jamatu.Auth.Application.Infrastructure
{
    public interface IMappingAdapter
    {
        public IMapper Mapper { get; }
    }
}
