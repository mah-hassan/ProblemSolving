class Result
{

    /*
     * Complete the 'circularArrayRotation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER k
     *  3. INTEGER_ARRAY queries
     */

    public static List<int> circularArrayRotation(List<int> a, int k,
     List<int> queries)
    {



        var c = new List<int>(a.Count);

        k = k > a.Count ? k % a.Count : k;

        int i = a.Count - k;

        if (k == a.Count)
        {
            c = a;
        }
        else
        {
            while (c.Count != a.Count)
            {
                if (i == a.Count)
                {
                    i = 0;
                }

                c.Add(a[i]);

                i++;
              
            }
        }

        var result = new List<int>();

        foreach (int q in queries)
        {           
            result.Add(c[q]);
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');


        int k = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> queries = new List<int>();

        for (int i = 0; i < q; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<int> result = Result.circularArrayRotation(a, k, queries);

        Console.WriteLine(String.Join("\n", result));

    }
}
