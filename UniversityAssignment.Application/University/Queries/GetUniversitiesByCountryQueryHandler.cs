using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Application.University.DTO;
using UniversityAssignment.Infrastructure.Abstract;

namespace UniversityAssignment.Application.University.Queries
{
    public class GetUniversitiesByCountryQueryHandler(IUniversityRepository restaurantsRepository,
   IMapper mapper) : IRequestHandler<GetUniversitiesByCountry, List<UniversityDTO?>>
    {
        public async Task<List<UniversityDTO?>> Handle(GetUniversitiesByCountry request, CancellationToken cancellationToken)
        {
            var CountryISO2Code = restaurantsRepository.GetCountryByIdAsync(request.CountryId);
            if (CountryISO2Code.Result != null)
            {

                var restaurant = restaurantsRepository.GetUniversitiesByCountry(CountryISO2Code.Result.Country_ID);
                var restaurantDto = mapper.Map<List<UniversityDTO?>>(restaurant);
                return restaurantDto;
            }
            return null;

        }
    }
}
