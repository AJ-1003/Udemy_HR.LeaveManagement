using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using HR.LeaveManagement.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class Get_LeaveTypeDetailRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly Get_LeaveTypeDetailRequestHandler _handler;
        private readonly Guid _leaveTypeId;

        public Get_LeaveTypeDetailRequestHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _leaveTypeId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");

            _handler = new Get_LeaveTypeDetailRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetLeaveTypeDetailsTest()
        {
            var result = await _handler.Handle(new Get_LeaveTypeDetailRequest() { Id = _leaveTypeId }, CancellationToken.None);

            var resultDTO = _mapper.Map<LeaveType>(result);

            resultDTO.ShouldBeOfType<LeaveType>();
        }
    }
}
