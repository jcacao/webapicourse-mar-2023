using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;

namespace EmployeesApi.AutomapperProfiles;

public class Employees : Profile
{
    public Employees()
    {

        CreateMap<EmployeeEntity, WorkContactItem>()
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.WorkPhone))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.WorkEmail));

        CreateMap<EmployeeEntity, HomeContactItem>()
           .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.HomePhone))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.HomeEmail));

        CreateMap<EmployeeEntity, EmployeeResponse>()
            .ForMember(dest => dest.EmployeeId,
            opts => opts.MapFrom(src => "A" + src.Id)) // Non-fulltime get an X, fulltime gets an A
            .ForMember(dest => dest.NameInformation,
                opts => opts.MapFrom(src => new NameInformation { FirstName = src.FirstName, LastName = src.LastName }
                ))
            .ForMember(dest => dest.WorkDetails, opts => opts.MapFrom(src => new WorkDetails { Department = src.Department }));
           


    }
}
