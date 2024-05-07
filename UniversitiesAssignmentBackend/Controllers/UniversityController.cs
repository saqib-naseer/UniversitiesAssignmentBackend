using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using UniversityAssignment.Application.University.Command.CreateUniversity;
using UniversityAssignment.Application.University.Command.UpdateUniversity;
using UniversityAssignment.Application.University.DTO;
using UniversityAssignment.Application.University.Queries;
using UniversityAssignment.Infrastructure.Abstract;

namespace UniversitiesAssignmentBackend.Controllers
{
    public class UniversityController(IMediator mediator) : ControllerBase
    {

        [HttpPost("createUniversity")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUniversity(CreateUniversityCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityDTO?>> GetById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(restaurant);
        }

        [HttpPatch("updateUniversity/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUniversity([FromRoute] int id, UpdateUniversityCommand command)
        {
            command.Id = id;
            await mediator.Send(command);

            return NoContent();
        }
    }

}