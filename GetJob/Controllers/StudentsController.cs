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
    public class StudentsController : ControllerBase
    {
        private IStudentsServices _studentsService;
        public StudentsController(IStudentsServices studentsService)
        {
            _studentsService = studentsService;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            

            var result = _studentsService.GetStudents();


            return Ok(result);
        }
        [HttpGet("search")]
        public IActionResult TextSearch(string text)
        {
            List<Students> result = new List<Students>();
           
                result = _studentsService.TextSearch(text).ToList();
            

            return Ok(result);
        }

    }
}
