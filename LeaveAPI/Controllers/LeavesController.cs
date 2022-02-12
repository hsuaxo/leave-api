using LeaveAPI.Models;
using LeaveAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeaveAPI.Controllers
{
    [ApiController]
    public class LeavesController : Controller
    {
        private readonly ILeaveService leaveService;

        public LeavesController(ILeaveService leaveService)
        {
            this.leaveService = leaveService;
        }

        [HttpGet("type/list")]
        public IEnumerable<LeaveType> GetAllLeaveTypes()
        {
            return leaveService.GetAllLeaveTypes();
        }

        [HttpGet("leave/list")]
        public IEnumerable<Leave> GetAllLeaves()
        {
            return leaveService.GetAllLeaves();
        }

        [HttpGet("leave/{id}")]
        public Leave GetLeave(int id)
        {
            return leaveService.GetLeave(id);
        }

        [HttpPost("leave")]
        public IActionResult SaveLeave([FromBody] Leave leave)
        {
            leaveService.SaveLeave(leave);
            return Ok();
        }

        [HttpPut("leave")]
        public IActionResult UpdateLeave([FromBody] Leave leave)
        {
            leaveService.SaveLeave(leave);
            return Ok();
        }

        [HttpDelete("leave/{id}")]
        public IActionResult DeleteLeave(int id)
        {
            leaveService.DeleteLeave(id);
            return Ok();
        }
    }
}