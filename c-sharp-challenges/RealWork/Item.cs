using System.ComponentModel.DataAnnotations;

namespace c_sharp_challenges.RealWork
{
	public record Item(string Name, decimal Price, int Quantity, bool Taxable) : IValidatableObject
	{
		public Item(Dictionary<string, object> item)
			: this(PreValidation<string>(item["name"]), PreValidation<decimal>(item["price"]),
				  PreValidation<int>(item["quantity"]), PreValidation<bool>(item["taxable"]))
		{

		}

		private static T PreValidation<T>(object value)
		{
			try
			{
				return (T)value;
			}
			catch (Exception)
			{
				Console.WriteLine($"Not possible to convert {value} into type {typeof(T)}. Check the input");
				return default;
			}			
		}

		//Write a function to validate the items when unboxing 

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();

			if (string.IsNullOrEmpty(Name))
				results.Add(new ValidationResult("Name should not be empty"));

			if (Price <= 0)
				results.Add(new ValidationResult("Price should be greater than 0"));

			if (Quantity < 1)
				results.Add(new ValidationResult("The product must have quantity greater than 1 "));


			return results;
		}
	}
}
