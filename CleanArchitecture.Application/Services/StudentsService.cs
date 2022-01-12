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
    public class StudentsService : IStudentsServices
    {
        public IStudentsRepository _studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        public StudentClassesViewModel GetStudents()
        {
            return new StudentClassesViewModel()
            {
                Students = _studentsRepository.GetStudents()
            };
        }
        public IEnumerable<Students> TextSearch(string text)
        {
            IEnumerable<Students> result = new List<Students>();
           
                result = _studentsRepository.TextSearch(text);
           
            return result;
        }


    }
}
