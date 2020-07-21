using System;
using System.Collections.Generic;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            var quote = _service.GetAnyQuote();
            QuoteView quoteView = new QuoteView()
            {
                Actor = quote.Actor,
                Detail = quote.Detail,
                Id = quote.Id
            };

            return quoteView;
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            var actorQuote = _service.GetAnyQuote(actor);

            if (actorQuote == null) return NotFound();

            QuoteView quoteView = new QuoteView()
            {
                Actor = actorQuote.Actor,
                Detail = actorQuote.Detail,
                Id = actorQuote.Id
            };

            return quoteView;
        }

    }
}
