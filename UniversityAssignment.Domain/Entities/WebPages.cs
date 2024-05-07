using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAssignment.Domain.Entities
{
    public class UniversityWebPages
    {
        [Key]
        public int Id { get; set; }
        public int UniversityId { get; set; }
        public string WebPages { get; set; }

    }
}
