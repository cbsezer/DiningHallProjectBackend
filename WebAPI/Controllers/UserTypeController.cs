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
    public class UserTypeController : ControllerBase
    {
        IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet("UserTypeMonthlySpending")]
        public IActionResult UserTypeMonthlySpending(string month, int userType)
        {
            var result = _userTypeService.UserTypeMonthlySpending(month, userType);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("UserTypeInformation")]
        public IActionResult UserTypeInformation(int cardNumber)
        {
            var result = _userTypeService.UserTypeInformation(cardNumber);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("UserTypeList")]
        public IActionResult UserTypeList(string type)
        {
            var result = _userTypeService.UserTypeList(type);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

    }
}
