using System.Collections.Generic;
using dotnet_webapi.Models;

namespace dotnet_webapi.Repositories
{
    public interface IFeedbackRepository
    {
        void Add(Feedback feedback);
        IEnumerable<Feedback> Find(FeedbackQueryCriteria query);
        Feedback Get(int id);
        IEnumerable<Feedback> GetAll();
    }
}