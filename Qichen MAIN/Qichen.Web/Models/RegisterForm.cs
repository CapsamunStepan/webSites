using System.ComponentModel.DataAnnotations;

namespace Qitchen.Web.Models
{
	public class RegisterForm
	{
		[Required]
		[StringLength(32)]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[MaxLength(32)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[MaxLength(32)]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string PasswordConfirm { get; set; }
	}
}