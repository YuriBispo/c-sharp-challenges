using c_sharp_challenges.CodeChallenge;

namespace c_sharp_challenges_test
{
	public class HackerRankTests
	{
		List<Dictionary<string, object>> Items;
		decimal TaxRate;

		public HackerRankTests()
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
		public void Should_SumAllValuesCorrectly_When_InputIsValid()
		{
			Setup();
			var sum = HackerRank.CalculateTotalCost(Items, TaxRate);

			Assert.Equal(2824.48M, sum);
		}

		[Fact]
		public void Should_ReturnMinusOneAndErrorMessage_When_InputCannotBeUnboxed()
		{
			Setup();
			Items[2]["price"] = 220; // int type
			var sum = HackerRank.CalculateTotalCost(Items, TaxRate);

			Assert.Equal(-1, sum);
		}

		[Fact]
		public void Should_ReturnZero_When_InputListIsEmpty()
		{
			var sum = HackerRank.CalculateTotalCost(Items, TaxRate);

			Assert.Equal(0, sum);
		}
	}
}
