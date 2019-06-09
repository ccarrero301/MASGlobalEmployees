using AutoMapper;

namespace MASGlobal.Employees.WebApi.Mappings
{
    public class MappingConfiguration
    {
        public static IMapper Configure()
        {
            var mappingConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfiguration.CreateMapper();

            return mapper;
        }
    }
}