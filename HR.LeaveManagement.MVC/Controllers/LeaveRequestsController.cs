using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.LeaveRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR.LeaveManagement.MVC.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly IMapper _mapper;

        public LeaveRequestsController(ILeaveRequestService leaveRequestService, ILeaveTypeService leaveTypeService, IMapper mapper)
        {
            _leaveRequestService = leaveRequestService;
            _leaveTypeService = leaveTypeService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrator")]
        // GET: LeaveRequest
        public async Task<ActionResult> Index()
        {
            var model = await _leaveRequestService.GetAdminLeaveRequestList();
            return View(model);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _leaveRequestService.GetAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> ApproveRequest(Guid id, bool approved)
        {
            try
            {
                await _leaveRequestService.ApproveLeaveRequest(id, approved);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: LeaveRequestsController/Create
        public async Task<ActionResult> Create()
        {
            var leaveTypes = await _leaveTypeService.GetAllAsync();
            var leaveTypeItems = new SelectList(leaveTypes, "Id", "Name");
            var model = new Create_LeaveRequestVM
            {
                LeaveTypes = leaveTypeItems
            };
            return View(model);
        }

        // POST: LeaveRequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Create_LeaveRequestVM newLeaveRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _leaveRequestService.CreateAsync(newLeaveRequest);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }

            var leaveTypes = await _leaveTypeService.GetAllAsync();
            var leaveTypeItems = new SelectList(leaveTypes, "Id", "Name");
            newLeaveRequest.LeaveTypes = leaveTypeItems;

            return View(newLeaveRequest);
        }
    }
}
