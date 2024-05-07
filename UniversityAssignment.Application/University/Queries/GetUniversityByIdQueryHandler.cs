using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Application.University.DTO;
using UniversityAssignment.Infrastructure.Abstract;

namespace UniversityAssignment.Application.University.Queries
{
    public class GetUniversityByIdQueryHandler(IUniversityRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetUniversityByIdQuery, UniversityDTO>
    {
        public async Task<UniversityDTO> Handle(GetUniversityByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            var restaurantDto = mapper.Map<UniversityDTO>(restaurant);

            return restaurantDto;
        }
    }
}
