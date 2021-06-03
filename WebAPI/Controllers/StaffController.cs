using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost("AddStaff")]
        public IActionResult AddStaff(Staff staff)
        {

            var result = _staffService.Add(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("DeleteStaff")]
        public IActionResult DeleteStaff(int id)
        {
            var result = _staffService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllStaffs")]
        public IActionResult Get()
        {
            var result = _staffService.GetAll();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("StaffOfTheDay")]
        public IActionResult StaffOfTheDay()
        {
            var result = _staffService.StaffOfTheDay();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }
    }
}
