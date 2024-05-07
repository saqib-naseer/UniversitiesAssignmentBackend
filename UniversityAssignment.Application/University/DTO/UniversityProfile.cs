using AutoMapper;
using UniversityAssignment.Application.University.Command.CreateUniversity;
using UniversityAssignment.Application.University.DTO;
using UniversityAssignment.Domain.Entities;

namespace UniversitiesAssignmentBackend.App_Start
{
    public class UniversityProfile : Profile
    {
        public UniversityProfile()
        {
            CreateMap<UniversityDTO, University>().ReverseMap();
            CreateMap<CreateUniversityCommand, University>().ReverseMap();
        }

    }
}
