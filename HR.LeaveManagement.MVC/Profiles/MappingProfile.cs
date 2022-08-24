using AutoMapper;
using HR.LeaveManagement.MVC.Models.Auth;
using HR.LeaveManagement.MVC.Models.LeaveAllocations;
using HR.LeaveManagement.MVC.Models.LeaveRequests;
using HR.LeaveManagement.MVC.Models.LeaveTypes;
using HR.LeaveManagement.MVC.Models.Users;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Leave Request
            CreateMap<LeaveRequestDTO, LeaveRequestVM>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateRequested.DateTime))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.DateTime))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.DateTime))
                .ReverseMap();
            CreateMap<LeaveRequestListDTO, LeaveRequestVM>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateRequested.DateTime))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.DateTime))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.DateTime))
                .ReverseMap();
            CreateMap<Create_LeaveRequestDTO, Create_LeaveRequestVM>()
                .ReverseMap();

            // Leave Allocation
            CreateMap<LeaveAllocationDTO, LeaveAllocationVM>()
                .ReverseMap();
            CreateMap<Create_LeaveAllocationDTO, Create_LeaveAllocationVM>()
                .ReverseMap();

            // Leave Type
            CreateMap<LeaveTypeDTO, LeaveTypeVM>()
                .ReverseMap();
            CreateMap<Create_LeaveTypeDTO, Create_LeaveTypeVM>()
                .ReverseMap();

            // Register
            CreateMap<RegisterVM, RegistrationRequest>()
                .ReverseMap();

            // Employee
            CreateMap<EmployeeVM, Employee>()
                .ReverseMap();
        }
    }
}
