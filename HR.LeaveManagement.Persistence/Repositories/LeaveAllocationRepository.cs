using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveAllocationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, Guid leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(la => la.EmployeeId == userId && la.LeaveTypeId == leaveTypeId && la.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Include(la => la.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations
                .Where(la => la.EmployeeId == userId)
                .Include(la => la.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(Guid id)
        {
            var leaveAllocation = await _context.LeaveAllocations
                .Include(la => la.LeaveType)
                .FirstOrDefaultAsync(la => la.Id == id);
            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, Guid leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(la => la.EmployeeId == userId && la.LeaveTypeId == leaveTypeId);
        }
    }
}
