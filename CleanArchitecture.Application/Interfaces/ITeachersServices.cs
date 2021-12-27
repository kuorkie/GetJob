using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.DomainCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ITeachersServices
    {
        ProjectViewModel GetTeachers();
        IEnumerable<Teachers> TextSearch(string text);
    }
}
