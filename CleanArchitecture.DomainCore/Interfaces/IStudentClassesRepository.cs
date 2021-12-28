using CleanArchitecture.DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DomainCore.Interfaces
{
    public interface IStudentClassesRepository
    {
        IEnumerable<StudentClass> GetResults();
        IEnumerable<StudentClass> TextSearch(string text);
    }
}
