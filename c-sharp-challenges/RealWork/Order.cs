using System.ComponentModel.DataAnnotations;

namespace c_sharp_challenges.RealWork
{
	public record Order
	{
		public ICollection<Item> Items { get; private set; }
		public decimal TaxRate { get; private set; }

		public Order(List<Dictionary<string, object>> items, decimal taxRate)
		{
			Items = new List<Item>();
			foreach (var item in items)
			{
				Items.Add(new Item(item));
			};

			TaxRate = taxRate;
		}

		public decimal CalculateTotalCost()
		{
			if (Items.Count == 0) return 0;

			decimal sum = 0;
			int index = 1;
			foreach (var item in Items)
			{
				var errors = item.Validate(new ValidationContext(item));
				if (errors.Count() > 0)
				{
					foreach (var error in errors)
					{
						Console.WriteLine($"Item #{index}: {error}");
					}
					
					return -1;
				}

				decimal subTotal = item.Price * item.Quantity;

				sum += CalculateSubTotal(item.Price, item.Quantity, item.Taxable);
				index++;
			}

			return Math.Round(sum, 2);
		}

		private decimal CalculateSubTotal(decimal value, decimal qty, bool taxable)
		{
			decimal subTotal = value * qty;
			decimal taxes = subTotal * TaxRate;

			return subTotal - (taxable ? taxes : 0);
		}
	}
}
