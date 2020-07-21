using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context
                .Candidates
                .Where(candidate => candidate.AccelerationId == accelerationId &&
                candidate.UserId == userId)
                .Select(candidate => candidate.Acceleration.Challenge)
                .Distinct()
                .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
                _context.Add(challenge);
            else
                _context.Update(challenge);

            _context.SaveChanges();

            return challenge;
        }
    }
}