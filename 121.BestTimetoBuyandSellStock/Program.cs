int[] stockPrices = [7, 1, 5, 3, 6, 4];

var profit = new Solution().MaxProfit(stockPrices);

Console.WriteLine(profit); // Output: 5
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int buy = prices[0], profit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < buy)
                buy = prices[i];
            else 
                profit = Math.Max(profit, prices[i] - buy);
        }
        return profit;
    }
}