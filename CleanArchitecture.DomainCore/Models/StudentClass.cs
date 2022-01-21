using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DomainCore.Models
{
   public class StudentClass
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int StudentsId { get; set; }
        
        public Classes Class { get; set; }
        public Students Students { get; set; }
    }
}
