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
    public class TeachersRepository:ITeachersRepository
    {
        public GetJobDbContext _context;
        public TeachersRepository(GetJobDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Teachers> GetTeachers()
        {
            return _context.Teachers;
        }
        public IEnumerable<Teachers> TextSearch(string text)
        {

            var result = new List<Teachers>();

            result = _context.Teachers.Where(x => x.Surname.Contains(text)).ToList();

            return result;
        }
    }
}
