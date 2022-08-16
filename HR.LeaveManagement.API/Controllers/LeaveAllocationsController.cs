using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
        {
            var response = await _mediator.Send(new Get_LeaveAllocationListRequest());
            return response;
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LeaveAllocationDTO>> Get(Guid id)
        {
            var response = await _mediator.Send(new Get_LeaveAllocationDetailRequest
            {
                Id = id
            });
            return response;
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Create_LeaveAllocationDTO newLeaveAllocation)
        {
            var response = await _mediator.Send(new Create_LeaveAllocationCommand
            {
                LeaveAllocationDTO = newLeaveAllocation
            });
            return Ok(response);
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Update_LeaveAllocationDTO updatedLeaveAllocation)
        {
            var response = await _mediator.Send(new Update_LeaveAllocationCommand
            {
                Id = id,
                LeaveAllocationDTO = updatedLeaveAllocation
            });
            return Ok(response);
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new Delete_LeaveAllocationCommand
            {
                Id = id
            });
            return Ok(response);
        }
    }
}
