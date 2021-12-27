using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.DomainCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private ITeachersServices _teachersService;
        public TeachersController(ITeachersServices teachersService)
        {
            _teachersService = teachersService;
        }
        [HttpGet]
        public IActionResult GetTeachers()
        {


            var result = _teachersService.GetTeachers();


            return Ok(result);
        }
        [HttpGet("search")]
        public IActionResult TextSearch(string text)
        {
            List<Teachers> result = new List<Teachers>();

            result = _teachersService.TextSearch(text).ToList();


            return Ok(result);
        }
        
    }
}
