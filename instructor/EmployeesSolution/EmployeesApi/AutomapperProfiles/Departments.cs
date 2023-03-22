using AutoMapper;

namespace EmployeesApi.AutomapperProfiles;

public class Departments : Profile
{
    public Departments()
    {

        CreateMap<DepartmentEntity, DepartmentItem>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Code));
    }
}
