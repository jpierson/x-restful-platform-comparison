using dotnet_webapi.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnet_webapi.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly Dictionary<int, Feedback> _store;

        public FeedbackRepository()
        {
            _store = new Dictionary<int, Feedback>();
        }

        public void Add(Feedback feedback)
        {
            _store.Add(feedback.Id, feedback);
        }

        public Feedback Get(int id)
        {
            return _store[id];
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _store.Values;
        }

        public IEnumerable<Feedback> Find(FeedbackQueryCriteria query)
        {
            if (query.Pattern != null)
            {
                return _store.Values
                    .Where(f => f.Comment.IndexOf(query.Pattern, StringComparison.InvariantCultureIgnoreCase) >= 0);
            }

            return GetAll();
        }
    }

    public class FeedbackQueryCriteria
    {
        public FeedbackQueryCriteria(string pattern)
        {
            this.Pattern = pattern;
        }

        public string Pattern { get; }
    }
}