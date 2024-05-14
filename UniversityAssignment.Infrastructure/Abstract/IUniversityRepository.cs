using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Domain.Entities;

namespace UniversityAssignment.Infrastructure.Abstract
{
    public interface IUniversityRepository
    {
        Task SaveChanges();
        Task<int> CreateUniversity(University entity);
        Task<int> CreateWebPages(UniversityWebPages entity);
        Task<int> CreateDomains(Domains entity);
        bool CreateUniversityList(University entity);

        int DeleteWebPages(IEnumerable<UniversityWebPages> webPages);
        int DeleteDomains(IEnumerable<Domains> domains);

        Task<University?> GetByIdAsync(int id);
        Task<LK_Country?> GetCountryByIdAsync(string countryId);
        IEnumerable<Domains> GetUniversityDomains(int universityId);
        IEnumerable<UniversityWebPages> GetUniversityWebPages(int universityId);
        List<University?> GetUniversitiesByCountry(string country);

        bool UpdateUniversity(int universityId, UpdateUniversityModel model);
    }
}
