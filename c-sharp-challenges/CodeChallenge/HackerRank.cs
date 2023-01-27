namespace c_sharp_challenges.CodeChallenge
{
    // This class is supposed to deal with the challenge like we commonly see in HackerRank or LeetCode exercises.
    // Just a class with a method and some test cases
    public class HackerRank
    {
        public static decimal CalculateTotalCost(List<Dictionary<string, object>> items, decimal taxRate)
        {
            try
            {
                if (items.Count == 0) return 0;

                decimal sum = 0;
                foreach (var item in items)
                {
                    if (!IsValid(item))
                        throw new Exception("Item not valid. Check the parameters sent.");

                    decimal subTotal = (decimal)item["price"] * (int)item["quantity"];

                    sum += (bool)item["taxable"] ? subTotal - (subTotal * taxRate) : subTotal;
                }

                return Math.Round(sum, 2);
            }
            catch (Exception)
            {
                Console.WriteLine("Impossible to calculate");
                return -1;
            }
        }

        private static bool IsValid(Dictionary<string, object> item)
        {
            item.TryGetValue("name", out var name);
            item.TryGetValue("price", out var price);
            item.TryGetValue("quantity", out var quantity);
            item.TryGetValue("taxable", out var taxable);

            return name is not null || price is not null || quantity is not null || taxable is not null;
        }
    }
}
