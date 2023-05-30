using Qitchen.BusinessLogic.Database;
using Qitchen.Domain.Entities;
using Qitchen.Helpers;
using System;
using System.Data.Entity;
using System.Linq;

namespace Qitchen.BusinessLogic.Service
{
    public class AuthService : Service
    {
        public struct LoginData
        {
            public string Email { get; set; }
            public string Password { get; set; }    
            public string IpAddress { get; set; }
            public DateTime Time { get; set; }
		}

		public EntryServiceResponse<Session> Login(LoginData data)
		{
			var passHash = AuthHelper.GeneratePasswordHash(data.Password);

			var user = DbContext.Users.FirstOrDefault(x => x.Email == data.Email && x.PasswordHash == passHash);
			if (user == null)
				return Failure<EntryServiceResponse<Session>>("User with this pair not found.");

			user.LastIpAddress = data.IpAddress;
			user.LastLoginTime = data.Time;
            DbContext.Entry(user).State = EntityState.Modified;
            DbContext.SaveChanges();

			//
			// Create session and store token in Cookie.
			//

			using (var sessionService = new SessionService())
			{
				var session = new Session
				{
					Token = AuthHelper.GenerateSessionToken(user.Name),
					User = user
				};

				var crResp = sessionService.Create(session);
				if(!crResp.Success)
					return Failure<EntryServiceResponse<Session>>(crResp.Message);

				return Entry(session);
			}
		}

		public struct RegisterData
		{
			public string Name { get; set; }
			public string Email { get; set; }
			public string Password { get; set; }
			public string IpAddress { get; set; }
			public DateTime Time { get; set; }
		}

		public ServiceResponse Register(RegisterData data)
		{
			using (var uService = new UserService())
			{
				if (uService.GetByEmail(data.Email).Entry != null)
					return Failure("Account with this Email already exists.");
			}

			var user = new User
			{
				Name = data.Name,
				Email = data.Email,
				PasswordHash = AuthHelper.GeneratePasswordHash(data.Password),
				LastIpAddress = data.IpAddress,
				LastLoginTime = data.Time,
				Role = UserRole.User
			};

			DbContext.Users.Add(user);
            DbContext.SaveChanges();
			return Success();
		}
	}
}
