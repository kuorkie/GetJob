using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.DomainCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private IClassesServices _classesService;
        public ClassesController(IClassesServices classesService)
        {
            _classesService = classesService;
        }
        [HttpGet]
        public IActionResult GetClasses()
        {


            var result = _classesService.GetClasses();


            return Ok(result);
        }
        [HttpGet("search")]
        public IActionResult TextSearch(DayOfWeek text)
        {
            List<Classes> result = new List<Classes>();

            result = _classesService.TextSearch(text).ToList();


            return Ok(result);
        }
    }
}
