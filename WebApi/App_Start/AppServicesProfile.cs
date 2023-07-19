using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;
using WebApi.Models;

namespace WebApi
{
    public class AppServicesProfile : Profile
    {
        public AppServicesProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<BaseInfo, BaseDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<Employee, EmployeeInfo>()
                .ForMember(dest =>
                    dest.OccupationName,
                    opt => opt.MapFrom(src => src.Occupation))
                .ForMember(dest =>
                    dest.PhoneNumber,
                    opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest =>
                    dest.LastModifiedDateTime,
                    opt => opt.MapFrom(src => src.LastModified));
            CreateMap<EmployeeInfo, EmployeeDto>();
            CreateMap<ArSubledgerInfo, ArSubledgerDto>();
        }
    }
}