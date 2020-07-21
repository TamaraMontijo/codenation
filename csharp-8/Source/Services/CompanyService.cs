using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context
                .Candidates
                .Where(candidate => candidate.AccelerationId == accelerationId)
                .Select(candidate => candidate.Company)
                .Distinct()
                .ToList();
        }

        public Company FindById(int id)
        {
            return _context
                .Companies
                .Find(id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context
                .Candidates
                .Where(candidate => candidate.UserId == userId)
                .Select(candidate => candidate.Company)
                .Distinct()
                .ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id == 0)
                _context.Add(company);
            else
                _context.Update(company);

            _context.SaveChanges();

            return company;
        }
    }
}