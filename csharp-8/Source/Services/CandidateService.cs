using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context
                .Candidates
                .Where(candidate => candidate.AccelerationId == accelerationId)
                .ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context
                .Candidates
                .Where(candidates => candidates.CompanyId == companyId)
                .ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context
                .Candidates
                .Where(candidate =>
                candidate.UserId == userId &&
                candidate.AccelerationId == accelerationId &&
                candidate.CompanyId == companyId)
                .FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {
            var candidateExists = _context
                                    .Candidates
                                    .Any(x => x.UserId == candidate.UserId &&
                                    x.AccelerationId == candidate.AccelerationId &&
                                    x.CompanyId == candidate.CompanyId);


            if (!candidateExists)
                _context.Add(candidate);
            else
                _context.Update(candidate);

            _context.SaveChanges();

            return candidate;
        }
    }
}
