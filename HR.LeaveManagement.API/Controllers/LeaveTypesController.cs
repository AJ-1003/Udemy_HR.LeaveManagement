using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HR.LeaveManagement.Application.Responses;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> Get()
        {
            var response = await _mediator.Send(new Get_LeaveTypeListRequest());
            return Ok(response);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(Guid id)
        {
            var response = await _mediator.Send(new Get_LeaveTypeDetailRequest
            {
                Id = id
            });
            return Ok(response);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] Create_LeaveTypeDTO newLeaveType)
        {
            var response = await _mediator.Send(new Create_LeaveTypeCommand
            {
                LeaveTypeDTO = newLeaveType
            });
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(Guid id, [FromBody] LeaveTypeDTO updatedLeaveType)
        {
            var response = await _mediator.Send(new Update_LeaveTypeCommand
            {
                Id = id,
                LeaveTypeDTO = updatedLeaveType
            });
            return Ok(response);
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(Guid id)
        {
            var response = await _mediator.Send(new Delete_LeaveTypeCommand
            {
                Id = id
            });
            return Ok(response);
        }
    }
}
