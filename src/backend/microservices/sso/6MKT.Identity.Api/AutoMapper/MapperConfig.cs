using _6MKT.Identity.Api.AutoMapper.Profiles;
using AutoMapper;

namespace _6MKT.Identity.Api.AutoMapper
{
    public static class MapperConfig
    {
        public static MapperConfiguration Config() =>
            new MapperConfiguration(config =>
            {
                config.AddProfile<EntityToResponse>();
                config.AddProfile<RequestToEntity>();
            });
    }
}