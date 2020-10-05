using _6MKT.BackOffice.Api.AutoMapper.Profiles;
using AutoMapper;

namespace _6MKT.BackOffice.Api.AutoMapper
{
    public static class MapperConfig
    {
        public static MapperConfiguration Config() =>
            new MapperConfiguration(config =>
            {
                config.AddProfile<EntityToResponse>();
            });
    }
}