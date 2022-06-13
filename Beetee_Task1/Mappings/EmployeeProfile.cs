using AutoMapper;
using Beetee_Task.Domain.Entities;
using Beetee_Task.DTO;

namespace Beetee_Task.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDataDTO>()
                .ForMember(x => x.SecurityNumber, opt => opt.MapFrom(src => src.HR_Data.SecurityNumber))
                .ForMember(x => x.Salary, opt => opt.MapFrom(src => src.HR_Data.Salary));

            CreateMap<EmployeeDataDTO, Employee>()
                .ForMember(x => x.HR_Data, opt => opt.MapFrom(src => new HR_Data()
                {
                    Id = Guid.NewGuid(),
                    Salary = src.Salary,
                    SecurityNumber = src.SecurityNumber,
                    EmployeeID = src.Id
                }));

            
        }
    }
}