using AutoMapper;
using FluentValidation.Results;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class Create_LeaveTypeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly Create_LeaveTypeDTO _leaveTypeDTO;
        private readonly Create_LeaveTypeCommandHandler _handler;

        public Create_LeaveTypeCommandHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _leaveTypeDTO = new Create_LeaveTypeDTO
            {
                DefaultDays = 10,
                Name = "Test DTO"
            };

            _handler = new Create_LeaveTypeCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task CreateValidLeaveTypeTest()
        {
            var result = await _handler.Handle(new Create_LeaveTypeCommand() { LeaveTypeDTO = _leaveTypeDTO }, CancellationToken.None);
            var leaveTypes = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task CreateInvalidLeaveTypeTest()
        {
            _leaveTypeDTO.DefaultDays = -1;

            var result = await _handler.Handle(new Create_LeaveTypeCommand() { LeaveTypeDTO = _leaveTypeDTO }, CancellationToken.None);
            var leaveTypes = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            leaveTypes.Count.ShouldBe(2);
        }
    }
}
