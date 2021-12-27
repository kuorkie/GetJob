using CleanArchitecture.DomainCore.Interfaces;
using CleanArchitecture.DomainCore.Models;
using CleanArchitecture.Infrastucture.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastucture.Data.Repositories
{
    public class StudentsRepository:IStudentsRepository
    {
    
    public GetJobDbContext _context;
    public StudentsRepository(GetJobDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Students> GetStudents()
    {
        return _context.Students;
    }
        public IEnumerable<Students> TextSearch(string text)
        {

            var result = new List<Students>();
            
                result = _context.Students.Where(x => x.Name.Contains(text)).ToList();
            
            return result;
        }
    }
}
