using AutoMapper;
using Jamatu.Auth.Application.Register.Mapping;
using System.Collections.Generic;

namespace Jamatu.Auth.Application.Infrastructure
{
    public class MappingAdapter : IMappingAdapter
    {
        private readonly IMapper _mapper;
        public IMapper Mapper { get => _mapper; }

        public MappingAdapter()
        {
            var profiles = new List<Profile>
            {
                new RegisterProfile()
            };

            var config = new MapperConfiguration(cfg => { cfg.AddProfiles(profiles); });

            _mapper = config.CreateMapper();
        }
    }
}
