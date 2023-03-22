using AutoMapper;

namespace EmployeesApi.AutomapperProfiles;

public class Employees : Profile
{
    public Employees()
    {
        CreateMap<EmployeeEntity, EmployeeResponse>()
        .ForMember(dest => dest.EmployeeId,
        opts => opts.MapFrom(src => "A" + src.Id))
        .ForMember(dest => dest.NameInformation,
        opts => opts.MapFrom(src => new NameInformation { FirstName = src.FirstName, LastName = src.LastName }
        ))
        .ForMember(dest => dest.WorkDetails, opts => opts.MapFrom(src => new WorkDetails { Department = src.Department }))
        .ForMember(dest => dest.ContactInformation, opts => opts.MapFrom(src => new Dictionary<string, Dictionary<string, string>>
        {
         { "home", new Dictionary<string, string> {
         { "email", src.HomeEmail },
         { "phone", src.HomePhone }
         }
         }, { "work", new Dictionary<string, string> {
         { "email", src.WorkEmail },
         { "phone", src.WorkPhone }
         }
         } }));


    }
}
