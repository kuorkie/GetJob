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
       public  class ClassesService:IClassesServices
    {
         public IClassesRepository _classesRepository;
            public ClassesService(IClassesRepository studentsRepository)
            {
                _classesRepository = studentsRepository;
            }
            public StudentClassesViewModel GetClasses()
            {
                return new StudentClassesViewModel()
                {
                    Classes = _classesRepository.GetClasses()
                };
            }
            public IEnumerable<Classes> TextSearch(DayOfWeek text)
            {
                IEnumerable<Classes> result = new List<Classes>();

                result = _classesRepository.TextSearch(text);

                return result;
            }


        }
    }

