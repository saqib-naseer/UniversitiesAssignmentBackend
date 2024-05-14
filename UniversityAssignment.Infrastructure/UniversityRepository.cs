﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


        public bool UpdateUniversity(int universityId, UpdateUniversityModel model)
        {
            var result = dBContext.University.Where(x => x.Id == universityId).FirstOrDefault();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    result.Name = model.Name;
                }
                if (!string.IsNullOrEmpty(model.StateProvince))
                {
                    result.StateProvince = model.StateProvince;
                }
                if (!string.IsNullOrEmpty(model.AlphaTwoCode))
                {
                    result.AlphaTwoCode = model.AlphaTwoCode;
                }
                if (!string.IsNullOrEmpty(model.Country))
                {
                    result.Country = model.Country;
                }
                dBContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool CreateUniversityList(University entity)
        {
            dBContext.University.Add(entity);
            var result = dBContext.SaveChanges();
            if (result > 0)
            {
                return true;

            }
            return false;
        }
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
        public int DeleteDomains(IEnumerable<Domains> domains)
        {
            dBContext.Domains.RemoveRange(domains);
            return dBContext.SaveChanges();
        }

        public int DeleteWebPages(IEnumerable<UniversityWebPages> webPages)
        {
            dBContext.WebPages.RemoveRange(webPages);
            return dBContext.SaveChanges();
        }

        public async Task<University?> GetByIdAsync(int id)
        {
            var university = await dBContext.University
                .FirstOrDefaultAsync(x => x.Id == id);

            return university;
        }
        public List<University?> GetUniversitiesByCountry(string country)
        {
            var universitiesByCountry = dBContext.University.Where(x => x.Country == country).ToList();

            return universitiesByCountry;
        }
        public IEnumerable<UniversityWebPages> GetUniversityWebPages(int universityId)
        {
            var universityWebPages = dBContext.WebPages
                .Where(x => x.UniversityId == universityId).AsEnumerable();

            return universityWebPages;
        }

        public IEnumerable<Domains> GetUniversityDomains(int universityId)
        {
            var domains = dBContext.Domains
                .Where(x => x.UniversityId == universityId).AsEnumerable();

            return domains;
        }

        public async Task<LK_Country?> GetCountryByIdAsync(string countryId)
        {
            var university = await dBContext.LK_Country
                .FirstOrDefaultAsync(x => x.Country_ID == countryId);

            return university;
        }
    }
}
