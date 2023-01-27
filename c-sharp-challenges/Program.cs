#region Inputs
using c_sharp_challenges.CodeChallenge;
using c_sharp_challenges.RealWork;

var items = new List<Dictionary<string, object>>
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

decimal taxRate = 0.08M;

#endregion

Console.WriteLine($"HackerRank way of solving:");
Console.WriteLine(HackerRank.CalculateTotalCost(items, taxRate));
Console.WriteLine();
Console.WriteLine($"Closer to real work:");
Console.WriteLine(new Order(items, taxRate).CalculateTotalCost());