using AutoMapper;
using WebApplication5.Models;

namespace WebApplication5.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDepartmentEmployeeRequest, DepartmentEmployee>();
            CreateMap<UpdateDepartmentEmployeeRequest, DepartmentEmployee>();
        }
    }
}
