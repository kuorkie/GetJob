using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DomainCore.Models
{
     public class Classes
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public string Period { get; set; }
        public DayOfWeek Time { get; set; }
        public Classroom Classroom { get; set; }
        public Teachers Teachers { get; set; }
        public Subjects Subjects { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; }
    }
}
