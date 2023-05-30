using Qitchen.Domain.Entities;
using System.Web;

namespace Qitchen.Web.Extensions
{
	public static class SessionExtensions
	{
		public static User GetUser(this HttpSessionStateBase session)
		{
			return (User)session["__User"];
		}

		public static void ClearUser(this HttpSessionStateBase session)
		{
			session.Remove("__User");
		}

		public static void SetUser(this HttpSessionStateBase session, User user)
		{
			session["__User"] = user;
		}

		public static bool IsUserLoggedIn(this HttpSessionStateBase session)
		{
			return session.GetUser() != null;
		}

		public static bool UserHasRole(this HttpSessionStateBase session, UserRole role)
		{
			if (!session.IsUserLoggedIn())
				return false;

			var user = session.GetUser();
			return user.Role >= role;
		}
	}
}