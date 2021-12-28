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
    public class StudentClassesRepository : IStudentClassesRepository
    {
        public GetJobDbContext _context;
        public StudentClassesRepository(GetJobDbContext context)
        {
            _context = context;
        }
        public IEnumerable<StudentClass> GetResults()
        {
            return _context.StudentClasses;
        }
        public IEnumerable<StudentClass> TextSearch(string text)
        {
            var result = new List<StudentClass>();
            var studs = _context.StudentClasses.ToList();
            var k = _context.StudentClasses.Select(x=>x.Class).ToList();
            /*var teachers = from m  in _context.StudentClasses 
                           select m.Students ;
            teachers=teachers.Where(x=>x.Name.Contains(text));*/

            for (int i = 0; i < studs.Count(); i++)
            {

                if (!String.IsNullOrEmpty(text))
                {
                    // result[i].Students = _context.Students.Where(d => d.Name.Contains(text)).FirstOrDefault();
                    studs[i].Students = _context.Students.Where(x => x.Id == studs[i].StudentsId && x.Name.Contains(text)).FirstOrDefault();
                    studs[i].Class = _context.Classes.Where(x => x.Id == studs[i].ClassId ).FirstOrDefault();
                    if (studs[i].Students != null)
                    {
                        result.Add(studs[i]);
                    }
                }
                    
                
                   
                   
                
            }
            
            return result;
           /* for (int i = 0; i < result.Count(); i++)
            {
                result[i].Students = _context.Students.Where(x => x.Id == result[i].StudentsId).FirstOrDefault();
                    
            }
            

            result = _context.Students.Where(x => x.Name.Contains(text)).ToList();*/

            //return result;
        }
    }
}
