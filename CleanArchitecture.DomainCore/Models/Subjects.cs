using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.DomainCore.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Classes> Classes { get; set; }
    }
}
