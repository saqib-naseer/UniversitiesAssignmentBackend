﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAssignment.Application.University.Command.CreateUniversity
{
    public class CreateUniversityCommand : IRequest<int>
    {
        public List<string> Domains { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string StateProvince { get; set; } = default!;
        public string AlphaTwoCode { get; set; } = default!;
        public List<string> WebPages { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}