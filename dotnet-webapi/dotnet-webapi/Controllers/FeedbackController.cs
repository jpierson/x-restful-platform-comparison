using dotnet_webapi.Models;
using dotnet_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dotnet_webapi.Controllers
{
    public class FeedbackController : ApiController
    {
        private IFeedbackRepository _repository;

        public FeedbackController(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Feedback
        public IEnumerable<Feedback> Get(string pattern = null)
        {
            return _repository.Find(new FeedbackQueryCriteria(pattern));
        }

        // GET: api/Feedback/5
        public Feedback Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Feedback
        public void Post([FromBody]Feedback value)
        {
            _repository.Add(value);
        }
    }
}
