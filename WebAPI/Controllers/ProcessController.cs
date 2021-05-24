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

    }
}
