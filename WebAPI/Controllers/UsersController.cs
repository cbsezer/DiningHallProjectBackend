using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
    [ApiController] //attribute //class ile ilgili bilgi verme
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _userService.GetAll();

                return Ok(result);
            }catch(Exception ex)
            {
                var exceptionMessage = ex.Message;
                return BadRequest(exceptionMessage);

            }


        }

        //[HttpPost]
        //public IActionResult Post(User user)
        //{
        //    try
        //    {
        //      //  var result = _userService.Add(user);

        //      // return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        var exceptionMessage = ex.Message;
        //        return BadRequest(exceptionMessage);

        //    }


        //}
    }
}
