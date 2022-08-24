using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var id1 = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var id2 = Guid.NewGuid();

            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = id1,
                    DefaultDays = 10,
                    Name = "Test Annual"
                },
                new LeaveType
                {
                    Id = id2,
                    DefaultDays = 32,
                    Name = "Test Sick"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(mr => mr.GetAllAsync()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(mr => mr.GetAsync(leaveTypes.First().Id));

            mockRepo.Setup(mr => mr.CreateAsync(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                leaveType.Id = Guid.NewGuid();
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            //mockRepo.Setup(mr => mr.UpdateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            //{
            //    leaveTypes.Append(leaveType).Where(lt => lt.Id == id1);
            //    return leaveType;
            //});

            //mockRepo.Setup(mr => mr.DeleteAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            //{
            //    leaveTypes.Remove(leaveType);
            //    return leaveType;
            //});

            return mockRepo;
        }
    }
}
