using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.LeaveTypes;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeRepository;
        private readonly ILeaveAllocationService _leaveAllocationService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService, ILeaveAllocationService leaveAllocationService)
        {
            _leaveTypeRepository = leaveTypeService;
            _leaveAllocationService = leaveAllocationService;
        }

        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var model = await _leaveTypeRepository.GetAllAsync();
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _leaveTypeRepository.GetByIdAsync(id);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Create_LeaveTypeVM newLeaveType)
        {
            try
            {
                var response = await _leaveTypeRepository.CreateAsync(newLeaveType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(newLeaveType);
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _leaveTypeRepository.GetByIdAsync(id);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, LeaveTypeVM updatedLeaveType)
        {
            try
            {
                var response = await _leaveTypeRepository.UpdateAsync(id, updatedLeaveType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(updatedLeaveType);
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _leaveTypeRepository.DeleteAsync(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }

        // POST: LeaveTypesController/Allocate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Allocate(Guid id)
        {
            try
            {
                var response = await _leaveAllocationService.CreateAsync(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }
    }
}
