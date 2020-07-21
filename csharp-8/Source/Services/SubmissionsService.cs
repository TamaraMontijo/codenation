using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext _context;

        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return _context
                .Submissions
                .Where(submission => submission.User.Candidates.Any(
                    candidate => candidate.AccelerationId == accelerationId) &&
                    submission.ChallengeId == challengeId
                    )
                .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context
                .Submissions
                .Where(submission => submission.ChallengeId == challengeId)
                .OrderByDescending(submission => submission.Score)
                .First()
                .Score;
                
        }

        public Submission Save(Submission submission)
        {
            var submissionExists = _context
                .Submissions
                .Any(s => s.UserId == submission.UserId &&
                s.ChallengeId == submission.ChallengeId);

            if (submissionExists)
                _context.Update(submission);
            else
                _context.Add(submission);

            _context.SaveChanges();

            return submission;
        }
    }
}