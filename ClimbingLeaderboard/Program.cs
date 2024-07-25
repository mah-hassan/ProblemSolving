public static class Result
{

    /*
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> playerScores)
    {
        var result = new List<int>();
        // remove duplicated scores
        var leaderboard = ranked.Distinct().ToList();

        foreach (var score in playerScores)
        {
            var rank = BinarySearch(leaderboard, score);
            result.Add(rank);
        }
        return result;
    }
    private static int BinarySearch(List<int> leaderboard, int score)
    {
        int high = leaderboard.Count - 1;
        int low = 0;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            var midScore = leaderboard[mid];

            if (midScore == score)
                return mid + 1; // +1 to get rank not base 0 index
            else if (midScore > score)
                low = mid + 1;
            else
                high = mid - 1;
        }
        // if score not in leaderboard it shouid be in leaderboard[low] 
        return low + 1; // +1 to get rank not base 0 index
    }
}

class Solution
{
    public static void Main(string[] args)
    {

        int rankedCount = Convert.ToInt32(Console.ReadLine()?.Trim());

        List<int> ranked = Console.ReadLine()!.TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine()?.Trim());

        List<int> playerScores = Console.ReadLine()!.TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, playerScores);


        Console.WriteLine(String.Join("\n", result));
    }
}
