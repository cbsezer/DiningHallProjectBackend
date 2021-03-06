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

        [HttpGet("Login")]
        public IActionResult Login(int cardNo, string password)
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
            Console.WriteLine(result.Message);
            
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


        [HttpGet("GetMonthlyRegistration")]
        public IActionResult GetMonthlyGain(string month)
        {
            var result = _userService.MonthlyRegistration(month);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }


        [HttpGet("GetYearlyRegistration")]
        public IActionResult GetYearlyRegistration()
        {
            var result = _userService.YearlyRegistration();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        

        [HttpGet("TopVisitor")]
        public IActionResult TopVisitor()
        {
            var result = _userService.TopVisitor();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("TopSpender")]
        public IActionResult TopSpender()
        {
            var result = _userService.TopSpender();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        [HttpGet("MonthlyExpense")]
        public IActionResult MonthlyExpense()
        {
            var result = _userService.MonthlyExpense();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }
        [HttpGet("MonthlyVisitors")]
        public IActionResult MonthlyVisitors(string date)

        {
            var result = _userService.MonthlyVisitors(date);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }
        [HttpGet("WeeklyCalories")]
        public IActionResult WeeklyCalories(string date ,int cardNumber)

        {
            var result = _userService.WeeklyCalories(date, cardNumber);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

        
    }
}
