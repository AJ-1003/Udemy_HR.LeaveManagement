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
    public static class MockLeaveRequestRepository
    {
        public static Mock<ILeaveRequestRepository> GetLeaveRequestRepository()
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

            var lrId1 = Guid.NewGuid();
            var lrId2 = Guid.NewGuid();

            var leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id = lrId1,
                    LeaveTypeId = ltId1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    RequestComments = "Need a break"
                },
                new LeaveRequest
                {
                    Id = lrId2,
                    LeaveTypeId = ltId2,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    RequestComments = "Feeling sick"
                }
            };

            var mockRepo = new Mock<ILeaveRequestRepository>();

            mockRepo.Setup(mr => mr.GetAllAsync()).ReturnsAsync(leaveRequests);

            //mockRepo.Setup(mr => mr.GetAsync(It.IsAny<LeaveRequest>().Id)).ReturnsAsync((LeaveRequest leaveRequest) =>
            //{
            //    leaveRequests.FirstOrDefault(lr => lr.Id == lrId1);
            //    return leaveRequest;
            //});

            mockRepo.Setup(mr => mr.CreateAsync(It.IsAny<LeaveRequest>())).ReturnsAsync((LeaveRequest leaveRequest) =>
            {
                leaveRequest.Id = Guid.NewGuid();
                leaveRequests.Add(leaveRequest);
                return leaveRequest;
            });

            //mockRepo.Setup(mr => mr.UpdateAsync(It.IsAny<LeaveRequest>())).Returns((LeaveRequest leaveRequest) =>
            //{
            //    leaveRequest.RequestComments = "Need a vacation!!";
            //    leaveRequests.Append(leaveRequest).Where(lr => lr.Id == lrId1);
            //    return leaveRequest;
            //});

            //mockRepo.Setup(mr => mr.UpdateApprovalStatus(It.IsAny<LeaveRequest>(), true)).Returns((LeaveRequest leaveRequest) =>
            //{
            //    leaveRequest.Approved = true;
            //    leaveRequests.Append(leaveRequest).Where(lr => lr.Id == lrId1);
            //    return leaveRequest;
            //});

            //mockRepo.Setup(mr => mr.DeleteAsync(It.IsAny<LeaveRequest>())).Returns((LeaveRequest leaveRequest) =>
            //{
            //    leaveRequests.Remove(leaveRequest);
            //    return leaveRequest;
            //});

            return mockRepo;
        }
    }
}
