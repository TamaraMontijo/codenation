using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context
                .Candidates
                .Where(candidates => candidates.CompanyId == companyId)
                .Select(company => company.Acceleration)
                .Distinct()
                .ToList();
        }    

        public Acceleration FindById(int id)
        {
            return _context
                .Accelerations
                .Find(id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
                if (acceleration.Id == 0)
                    _context.Add(acceleration);
                else
                    _context.Update(acceleration);

                _context.SaveChanges();

                return acceleration;          
        }
    }
}