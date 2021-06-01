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
    public class MenuController : ControllerBase
    {

        IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost("AddMenu")]
        public IActionResult AddMenu(Menu menu)
        {

            var result = _menuService.Add(menu);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("DeleteMenu")]
        public IActionResult DeleteMenu(int id)
        {

            var result = _menuService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllMenus")]
        public IActionResult Get()
        {
            var result = _menuService.GetAll();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }


        [HttpGet("GetMenuDetail")]
        public IActionResult GetMenuDetail(string date)
        {
            var result = _menuService.GetMenuDetail(date);

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);

        }

    }
}
