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
    public class StudentClassesController : ControllerBase
    {
        private IStudentClassesServices _studentClassesService;
        public StudentClassesController(IStudentClassesServices studentClassesService)
        {
            _studentClassesService = studentClassesService;
        }
        [HttpGet("search")]
        public IActionResult TextSearch(string text)
        {
            List<StudentClass> result = new List<StudentClass>();

            result = _studentClassesService.TextSearch(text).ToList();


            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetResults()
        {


            var result = _studentClassesService.GetResults();


            return Ok(result);
        }
    }
}
