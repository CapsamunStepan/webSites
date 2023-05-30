using Qitchen.Domain.Entities;
using System.Data.Entity;
using System.Linq;

namespace Qitchen.BusinessLogic.Service
{
	public class SessionService : Service
	{
		public EntryServiceResponse<Session> GetByToken(string token)
		{
            var post = DbContext.Sessions
                .Include(x => x.User)
                .FirstOrDefault(x => x.Token == token);

            return Entry(post);
		}

		public ServiceResponse Create(Session session)
		{
			DbContext.Sessions.Add(session);
            DbContext.SaveChanges();

			return Success();
		}
	}
}
