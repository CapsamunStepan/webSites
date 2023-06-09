using System.Collections.Generic;

namespace Qitchen.Domain.Entities
{
	public class Menu
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Title { get; set; }
		public List<Product> Products { get; set; }
    }
}