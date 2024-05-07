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

            if (record != null)
            {
                mapper.Map(request, record);

                await universityRepository.SaveChanges();

                var oldDomains = universityRepository.GetUniversityDomains(record.Id);
                if (oldDomains.Any())
                {
                    _ = universityRepository.DeleteDomains(oldDomains);
                }
                if (request.Domains.Any())
                {
                    foreach (var domain in request.Domains)
                    {
                        _ = await universityRepository.CreateDomains(new Domains() { Domain = domain, UniversityId = record.Id });
                    }

                }

                var oldWebPages = universityRepository.GetUniversityWebPages(record.Id);
                if (oldWebPages.Any())
                {
                    _ = universityRepository.DeleteWebPages(oldWebPages);
                }
                if (request.WebPages.Any())
                {
                    foreach (var page in request.WebPages)
                    {
                        _ = await universityRepository.CreateWebPages(new UniversityWebPages() { WebPages = page, UniversityId = record.Id });
                    }
                }
            }

            return;
        }


    }
}
