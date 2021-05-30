using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute //class ile ilgili bilgi verme
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult LoginLogin(int cardNo, string password)
        {

            var result = _userService.Login(cardNo, password);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {

            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("AddBalance")]
        public IActionResult UpdateBalance(decimal balance, int cardNumber)
        {

            var result = _userService.UpdateBalance(balance, cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int cardNumber)
        {

            var result = _userService.Delete(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult Get()
        {
            var result = _userService.GetAll();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int cardNumber)
        {
            var result = _userService.GetById(cardNumber);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("GetAllUsersByBalance")]
        public IActionResult GetAllByBalance(decimal min, decimal max)
        {
            var result = _userService.GetAllByBalance(min, max);

            if (result.Success)
            {
                return Ok(result);

            }
            
            return BadRequest(result);
            
        }

       


    }
}
