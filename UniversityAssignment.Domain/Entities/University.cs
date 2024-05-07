using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAssignment.Domain.Entities
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        public string AlphaTwoCode { get; set; }
        public string Name { get; set; }
    }
}
