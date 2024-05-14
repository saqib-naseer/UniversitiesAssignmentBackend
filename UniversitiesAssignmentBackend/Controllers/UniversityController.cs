using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using UniversitiesAssignmentBackend.App_Start;
using UniversityAssignment.Application.University.Command.CreateUniversity;
using UniversityAssignment.Application.University.Command.UpdateUniversity;
using UniversityAssignment.Application.University.DTO;
using UniversityAssignment.Application.University.Queries;
using UniversityAssignment.Domain.Entities;
using UniversityAssignment.Infrastructure;
using UniversityAssignment.Infrastructure.Abstract;

namespace UniversitiesAssignmentBackend.Controllers
{
    [ApiController]
    [Route("api")]
    public class UniversityController(IMediator mediator, IUniversityRepository universityRepository, IMapper mapper) : ControllerBase
    {
        private readonly IUniversityRepository universityRepository = universityRepository;
        private readonly IMapper mapper = mapper;

        [HttpPost("createUniversity")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUniversity([FromBody] List<CreateUniversityCommand> command)
        {
            foreach (var model in command)
            {
                var universityModel = mapper.Map<University>(model);
                universityModel.Id = 0;
                var result = await universityRepository.CreateUniversity(universityModel);
            }

            return Ok(true);
        }


        [HttpGet("getUniversityByCountry/{countryCode}")]
        [AllowAnonymous]
        public async Task<ActionResult<UniversityDTO?>> GetUniversityByCountry([FromRoute] string countryCode)
        {
            var restaurant = await mediator.Send(new GetUniversitiesByCountry(countryCode));
            return Ok(restaurant);
        }

        [HttpGet("getUniversityById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UniversityDTO?>> GetById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetUniversityByIdQuery(id));
            return Ok(restaurant);
        }

        [HttpPatch("updateUniversity/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUniversity([FromRoute] int id, [FromBody] UpdateUniversityModel command)
        {

            var result = universityRepository.UpdateUniversity(id, command);
            return Ok(result);
            //command.Id = id;
            //await mediator.Send(command);

            //return NoContent();
        }
    }

}