using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Infrastructure.Abstract;

namespace UniversityAssignment.Application.University.Command.UpdateUniversity
{
    public class UpdateUniversityCommandHandler(IUniversityRepository universityRepository,
    IMapper mapper) : IRequestHandler<UpdateUniversityCommand>
    {
        public async Task Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
        {
            var record = await universityRepository.GetByIdAsync(request.Id.GetValueOrDefault());
            if (record is null)
            {
                return;
            }

            mapper.Map(request, record);

            await universityRepository.SaveChanges();
            return;
        }


    }
}
