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
    public class ProcessController : ControllerBase
    {

        IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpPost("EatFood")]
        public IActionResult AddProcess(int id)
        {

            var result = _processService.EatFood(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("DeleteProcess")]
        public IActionResult DeleteProcess(int id)
        {

            var result = _processService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllProcess")]
        public IActionResult Get()
        {
            var result = _processService.GetAll();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("GetUserMonthlySpending")]
        public IActionResult GetUserMonthlySpending(int userId, string month)
        {
            var result = _processService.GetUserMonthlySpending(userId, month);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

    }
}
