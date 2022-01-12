using CleanArchitecture.DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ViewModels
{
    public class StudentClassesViewModel
    {
        public IEnumerable<Students> Students { get; set; }
        public IEnumerable<Teachers> Teachers { get; set; }
        public IEnumerable<Classes> Classes { get; set; }

        public IEnumerable<StudentClass> Class { get; set; }

        public object StudentClass { get; internal set; }
    }
}
