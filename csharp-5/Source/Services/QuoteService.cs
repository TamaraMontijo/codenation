using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var totalQuotes = _context.Quotes.Count();
            var randomNumber = _randomService.RandomInteger(totalQuotes);

            var randomQuote = _context.Quotes
                .Where(x => x.Id == (randomNumber + 1))
                .First();

            return randomQuote;
        }

        public Quote GetAnyQuote(string actor)
        {
            var actorQuotes = _context.Quotes
                .Where(x => x.Actor == actor);
            var totalActorQuotes = actorQuotes.Count();

            if (totalActorQuotes == 0) return null;

            var randomNumber = _randomService.RandomInteger(totalActorQuotes);
            var randomActorQuote = actorQuotes.ToList()[randomNumber];

            return randomActorQuote;
        }
    }
}