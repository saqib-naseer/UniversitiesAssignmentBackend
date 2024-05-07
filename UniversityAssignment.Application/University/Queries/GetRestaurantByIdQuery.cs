using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Application.University.DTO;

namespace UniversityAssignment.Application.University.Queries
{
    public class GetRestaurantByIdQuery(int id) : IRequest<UniversityDTO>
    {
        public int Id { get; } = id;
    }
}
