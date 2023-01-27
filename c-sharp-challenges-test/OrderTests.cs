using c_sharp_challenges.RealWork;

namespace c_sharp_challenges_test
{
	public class OrderTests
	{
		List<Dictionary<string, object>> Items;
		decimal TaxRate;

		public OrderTests()
		{
			Items = new List<Dictionary<string, object>>();
		}

		private void Setup()
		{
			Items = new List<Dictionary<string, object>>
			{
				new Dictionary<string, object>
				{
					{ "name", "Nintendo Switch OLED - Pokémon Scarlet & Violet Edition"},
					{ "price", 359.0M },
					{ "quantity", 2 },
					{ "taxable", false }
				},
				new Dictionary<string, object>
				{
					{ "name", "Xbox Series X"},
					{ "price", 499.0M },
					{ "quantity", 1 },
					{ "taxable", false }
				},
				new Dictionary<string, object>
				{
					{ "name", "PlayStation 5"},
					{ "price", 499.0M },
					{ "quantity", 1 },
					{ "taxable", true }
				},
				new Dictionary<string, object>
				{
					{ "name", "GeForce RTX 3080 Ti"},
					{ "price", 1120.0M },
					{ "quantity", 1 },
					{ "taxable", true }
				},
				new Dictionary<string, object>
				{
					{ "name", "The Legend of Zelda: Breath of the Wild"},
					{ "price", 59.0M },
					{ "quantity", 2 },
					{ "taxable", false }
				},
			};

			TaxRate = 0.08M;
		}

		[Fact]
		public void Should_ReturnZero_When_CalculatingTotalCost_WithEmptyList()
		{			
			var order = new Order(Items, TaxRate);
			var result = order.CalculateTotalCost();

			Assert.Equal(0, result);
		}

		[Fact]
		public void Should_ReturnTheSum_When_CalculatingTotalCost_WithCorrectValues()
		{
			Setup();
			var order = new Order(Items, TaxRate);

			var result = order.CalculateTotalCost();

			Assert.Equal(2824.48M, result);
		}

		[Fact]
		public void Should_ReturnMinusOne_When_CalculatingTotalCost_WithInvalidTypeUnboxing()
		{
			Setup();
			Items[2]["price"] = 220; // int type
			var order = new Order(Items, TaxRate);

			var result = order.CalculateTotalCost();

			Assert.Equal(-1, result);
		}

		[Fact]
		public void Should_WriteToOutput_When_CalculatingTotalCost_WithInvalidTypeUnboxing()
		{
			Setup();
			Items[2]["price"] = 220; // int type
			var order = new Order(Items, TaxRate);

			var strWriter = new StringWriter();
			Console.SetOut(strWriter);

			var strReader = new StringReader("Price should be greater than 0");
			Console.SetIn(strReader);	

			var result = order.CalculateTotalCost();

			var output = strWriter.ToString();

			Assert.Contains("Price should be greater than 0", output);
		}
	}
}