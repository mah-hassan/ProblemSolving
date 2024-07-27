class Solution
{

    // Complete the flatlandSpaceStations function below.

    static int flatlandSpaceStationsv2(int n, int[] c)
    {
        Array.Sort(c);
        
        int maxDistance = 0;

        maxDistance = Math.Max(maxDistance, c[0]);

        for (int i = 1; i < c.Length; i++)
        {
            maxDistance = Math.Max(maxDistance, Math.Abs(c[i] - c[i - 1]) / 2);
        }
        maxDistance = Math.Max(maxDistance, (n - 1) - c[c.Length - 1]);

        return maxDistance;
    }
    static int flatlandSpaceStations(int n, int[] c)
    {
        int maxDistance = 0;
        var cities = Enumerable.Range(0, n).ToList();
        var stations = c.ToHashSet();
        int nearestStation = 0;
        for (int i = 0; i < cities.Count; i++)
        {
            nearestStation = stations.Contains(i) ? 
                i : c.MinBy(s => Math.Abs(s - cities[i]));
            maxDistance = Math.Max(maxDistance, Math.Abs(nearestStation - cities[i]));
        }
        return maxDistance;
    }

    static void Main(string[] args)
    {

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
        
        int result = flatlandSpaceStationsv2(n, c);

        Console.WriteLine(result);

    }
}
