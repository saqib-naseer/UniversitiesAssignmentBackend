using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Domain.Entities;
using UniversityAssignment.Infrastructure.Abstract;

namespace UniversityAssignment.Application.University.Command.CreateUniversity
{
    public class CreateUniversityCommandHandler(ILogger<CreateUniversityCommand> logger,
    IMapper mapper,
    IUniversityRepository repository) : IRequestHandler<CreateUniversityCommand, int>
    {
        public async Task<int> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
        {
            var universityModel = mapper.Map<Domain.Entities.University>(request);

            int id = await repository.CreateUniversity(universityModel);
            if (id != 0)
            {
                if (request.Domains.Any())
                {
                    foreach (var domain in request.Domains)
                    {
                        _ = await repository.CreateDomains(new Domains() { Domain = domain, UniversityId = id });
                    }

                }
                if (request.WebPages.Any())
                {
                    foreach (var page in request.WebPages)
                    {
                        _ = await repository.CreateWebPages(new UniversityWebPages() { WebPages = page, UniversityId = id });
                    }
                }
            }
            return id;
        }
    }

}
