using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DomainCore.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subjects_Taught { get; set; }
        public int Level { get; set; }

        public string Teacher_Image { get; set; }
        public ICollection<Classes> Classes { get; set; }
    }
}
