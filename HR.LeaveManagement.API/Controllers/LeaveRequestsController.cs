using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDTO>>> Get()
        {
            var response = await _mediator.Send(new Get_LeaveRequestListRequest());
            return Ok(response);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(Guid id)
        {
            var response = await _mediator.Send(new Get_LeaveRequestDetailRequest
            {
                Id = id
            });
            return Ok(response);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Create_LeaveRequestDTO newLeaveRequest)
        {
            var response = await _mediator.Send(new Create_LeaveRequestCommand
            {
                LeaveRequestDTO = newLeaveRequest
            });
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Update_LeaveRequestDTO updatedLeaveRequest)
        {
            var response = await _mediator.Send(new Update_LeaveRequestCommand
            {
                Id = id,
                LeaveRequestDTO = updatedLeaveRequest
            });
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>/ChangeApproval/5
        [HttpPut("ChangeApproval/{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] Update_LeaveRequestApprovalDTO updatedLeaveRequestApproval)
        {
            var response = await _mediator.Send(new Update_LeaveRequestCommand
            {
                Id = id,
                UpdateLeaveRequestApprovalDTO = updatedLeaveRequestApproval
            });
            return Ok(response);
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new Delete_LeaveRequestCommand
            {
                Id = id
            });
            return Ok(response);
        }
    }
}
