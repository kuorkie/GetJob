using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.DomainCore.Interfaces;
using CleanArchitecture.DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public  class StudentClassesService:IStudentClassesServices
    {
        public IStudentClassesRepository _studentClassesRepository;
        public StudentClassesService(IStudentClassesRepository studentClassesRepository)
        {
            _studentClassesRepository = studentClassesRepository;
        }
        public StudentClassesViewModel GetResults()
        {
            return new StudentClassesViewModel()
            {
                StudentClass = _studentClassesRepository.GetResults()
            };
        }
        public IEnumerable<StudentClass> TextSearch(string text)
        {
            IEnumerable<StudentClass> result = new List<StudentClass>();

            result = _studentClassesRepository.TextSearch(text);

            return result;
        }
    }
}
