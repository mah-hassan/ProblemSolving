class Result
{

    /*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        // simplest solution O(n^2) is best case
        /*
        int highest = 0;
        int result = 0;
        if (arr.Count == 1)
        {
            return arr[0];
        }
        int counter = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = 0; j < arr.Count; j++)
            {
                if (arr[i] == arr[j])
                    counter++; 
            }
            if (counter > highest)
            {
                highest = counter;
                result = arr[i];
            }
            else if (counter == highest)
            {
                result = Math.Min(result, arr[i]);
            }
            counter = 0;
        }
        return result;
        */
        // more effcient solution O(n^2) in worest case when all items is unique
        /*
                 int highest = 0;
        int result = 0;
        if (arr.Count == 1)
        {
            return arr[0];
        }
        HashSet<int> Checked = new HashSet<int>();
        int counter = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            if (Checked.Contains(arr[i]))
                continue;
            for (int j = 0; j < arr.Count; j++)
            {
                if (arr[i] == arr[j])
                    counter++;
            }
            if (counter > highest)
            {
                highest = counter;
                result = arr[i];
            }
            else if (counter == highest)
            {
                result = Math.Min(result, arr[i]);
            }
            counter = 0;
            Checked.Add(arr[i]);
        }

        return result;

         */
        // best soloution O(n) and more readable as well
        Dictionary<int, int> counts = new Dictionary<int, int>();
        foreach (int birdType in arr)
        {
            if (counts.ContainsKey(birdType))
            {
                counts[birdType]++;
            }
            else
            {
                counts.Add(birdType, 1);
            }
        }
        var highest = counts.Max(kv => kv.Value);
        return counts.Where(kv => kv.Value == highest)
            .Select(kv => kv.Key).Min();

    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd()
            .Split(' ').ToList()
            .Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        Console.WriteLine(result);

    }
}