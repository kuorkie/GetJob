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
    public class TeachersService : ITeachersServices
    {
        public ITeachersRepository _teachersRepository;
        public TeachersService(ITeachersRepository  teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }
        public StudentClassesViewModel GetTeachers()
        {
            return new StudentClassesViewModel()
            {
                Teachers = _teachersRepository.GetTeachers()
            };
        }
        public IEnumerable<Teachers> TextSearch(string text)
        {
            IEnumerable<Teachers> result = new List<Teachers>();

            result = _teachersRepository.TextSearch(text);

            return result;
        }



    }
}

