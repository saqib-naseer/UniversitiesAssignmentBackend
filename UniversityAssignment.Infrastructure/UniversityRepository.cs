using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Domain.Entities;
using UniversityAssignment.Infrastructure.Abstract;
using UniversityAssignment.Infrastructure.Persistance;

namespace UniversityAssignment.Infrastructure
{
    public class UniversityRepository(UniversityDBContext dBContext) : IUniversityRepository
    {
        public Task SaveChanges() => dBContext.SaveChangesAsync();

        public async Task<int> CreateUniversity(University entity)
        {
            dBContext.University.Add(entity);
            await dBContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<int> CreateWebPages(UniversityWebPages entity)
        {
            dBContext.WebPages.Add(entity);
            await dBContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<int> CreateDomains(Domains entity)
        {
            dBContext.Domains.Add(entity);
            await dBContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<University?> GetByIdAsync(int id)
        {
            var university = await dBContext.University
                .FirstOrDefaultAsync(x => x.Id == id);

            return university;
        }
        public async Task<LK_Country?> GetCountryByIdAsync(string countryId)
        {
            var university = await dBContext.LK_Country
                .FirstOrDefaultAsync(x => x.Country_ID == countryId);

            return university;
        }
    }
}
