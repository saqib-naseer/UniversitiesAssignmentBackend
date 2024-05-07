using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAssignment.Domain.Entities
{
    public class LK_Country
    {
        [Key]
        public string Country_ID { get; set; }
        public string Country_Name { get; set; }
        public string Alpha3Code { get; set; }
        public string CreatedOn { get; set; }
    }
}
