using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveAllocationRepository
    {
        public static Mock<ILeaveAllocationRepository> GetLeaveAllocationRepository()
        {
            var ltId1 = Guid.NewGuid();
            var ltId2 = Guid.NewGuid();

            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = ltId1,
                    DefaultDays = 10,
                    Name = "Test Annual"
                },
                new LeaveType
                {
                    Id = ltId2,
                    DefaultDays = 32,
                    Name = "Test Sick"
                }
            };

            var laId1 = Guid.NewGuid();
            var laId2 = Guid.NewGuid();

            var leaveAllocations = new List<LeaveAllocation>
            {
                new LeaveAllocation
                {
                    Id = laId1,
                    NumberOfDays = 10,
                    LeaveTypeId = ltId1
                },
                new LeaveAllocation
                {
                    Id = laId2,
                    NumberOfDays = 32,
                    LeaveTypeId = ltId2
                }
            };

            var mockRepo = new Mock<ILeaveAllocationRepository>();

            mockRepo.Setup(mr => mr.GetAllAsync()).ReturnsAsync(leaveAllocations);

            //mockRepo.Setup(mr => mr.GetAsync(leaveAllocations.FirstOrDefault(la => la.Id == laId1).Id));

            mockRepo.Setup(mr => mr.CreateAsync(It.IsAny<LeaveAllocation>())).ReturnsAsync((LeaveAllocation leaveAllocation) =>
            {
                leaveAllocation.Id = Guid.NewGuid();
                leaveAllocations.Add(leaveAllocation);
                return leaveAllocation;
            });

            //mockRepo.Setup(mr => mr.UpdateAsync(It.IsAny<LeaveAllocation>())).Returns((LeaveAllocation leaveAllocation) =>
            //{
            //    leaveAllocation.NumberOfDays = 12;
            //    leaveAllocations.Append(leaveAllocation).Where(la => la.Id == laId1);
            //    return leaveAllocation;
            //});

            //mockRepo.Setup(mr => mr.DeleteAsync(It.IsAny<LeaveAllocation>())).Returns((LeaveAllocation leaveAlloction) =>
            //{
            //    leaveAllocations.Remove(leaveAlloction);
            //    return leaveAlloction;
            //});

            return mockRepo;
        }
    }
}
