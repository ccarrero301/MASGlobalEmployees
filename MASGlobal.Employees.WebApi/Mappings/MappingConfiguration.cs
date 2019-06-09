using AutoMapper;

namespace MASGlobal.Employees.WebApi.Mappings
{
    public class MappingConfiguration
    {
        public static IMapper Configure()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            var mapper = mappingConfig.CreateMapper();

            return mapper;
        }
    }
}