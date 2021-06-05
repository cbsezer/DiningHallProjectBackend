using Business.Abstract;
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

    public class ShiftsController : ControllerBase
    {
        IShiftsService _shiftsService;

        public ShiftsController(IShiftsService shiftsService)
        {
            _shiftsService = shiftsService;
        }

        [HttpGet("MonthlyShifts")]
        public IActionResult MonthlyShifts(int staffId)
        {
            var result = _shiftsService.MonthlyShifts(staffId);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

    }
}
