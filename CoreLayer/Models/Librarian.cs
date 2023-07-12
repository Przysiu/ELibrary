using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Librarian
    {
        public int LibrarianId { get; set; }
        public string Name { get; set; }
        public string  Surname { get; set; }
        public string  position { get; set; }
        public DateTime EmploymentStart { get; set; }
        public int Salary { get; set; }
    }
}
