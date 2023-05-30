using Qitchen.Domain.Entities;
using Qitchen.Web.Extensions;
using System.Web.Mvc;

namespace Qitchen.Filters
{
	public class RequireUserRoleAttribute : ActionFilterAttribute
	{
		private UserRole Role { get; set; }

		public RequireUserRoleAttribute(UserRole role)
		{
			Role = role;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var session = filterContext.HttpContext.Session;
			if (!session.UserHasRole(Role))
			{
				// No permission - show 403 page.
				filterContext.Result = new HttpStatusCodeResult(403);
				return;
			}
		}
	}
}