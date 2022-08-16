using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Leave Request
            CreateMap<LeaveRequest, LeaveRequestDTO>()
                .ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDTO>()
                .ReverseMap();
            CreateMap<LeaveRequest, Create_LeaveRequestDTO>()
                .ReverseMap();
            CreateMap<LeaveRequest, Update_LeaveRequestDTO>()
                .ReverseMap();

            // Leave Allocation
            CreateMap<LeaveAllocation, LeaveAllocationDTO>()
                .ReverseMap();
            CreateMap<LeaveAllocation, Create_LeaveAllocationDTO>()
                .ReverseMap();
            CreateMap<LeaveAllocation, Update_LeaveAllocationDTO>()
                .ReverseMap();

            // Leave Type
            CreateMap<LeaveType, LeaveTypeDTO>()
                .ReverseMap();
            CreateMap<LeaveType, Create_LeaveTypeDTO>()
                .ReverseMap();
        }
    }
}
