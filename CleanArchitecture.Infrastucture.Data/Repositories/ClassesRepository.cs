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
    public class ClassesRepository:IClassesRepository
    {
        public GetJobDbContext _context;
        public ClassesRepository(GetJobDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Classes> GetClasses()
        {
            return _context.Classes;
        }
        public IEnumerable<Classes> TextSearch(DayOfWeek text
            
            )
        {

            var result = new List<Classes>();
            result = _context.Classes.Where(x=>x.Time==text).ToList();



           /* for (int i = 0; i < result.Count; i++)
            {
                result[i].Subjects = _context.Classes.Where(x => x.Subjects.Name.Contains(text));
                // result[i].Subjects =  _context.Subjects.FirstOrDefault(m => m.Id == result[i].SubjectId);
                //result = _context.Classes.FirstOrDefault(x => x.Period.Contains(text));
            }*/

            return result;
        }
    }
}
