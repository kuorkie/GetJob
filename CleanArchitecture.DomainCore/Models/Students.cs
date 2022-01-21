using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DomainCore.Models
{
   public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Name_of_Course { get; set; }
        public int Number_of_Course { get; set; }
        public string Nation { get; set; }
        public string Date_of_Birth { get; set; }
        public string Student_Image { get; set; }

        public ICollection<StudentClass> StudentClasses { get; set; }
    }
}


