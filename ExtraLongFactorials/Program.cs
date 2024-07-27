using System.Numerics;

class Result
{

    /*
     * Complete the 'extraLongFactorials' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void extraLongFactorials(int n)
    {
        BigInteger fact = new BigInteger();

        fact = CalculateFactorialRecursive(5);
        Console.WriteLine(fact); 
    }

    public static BigInteger CalculateFactorialRecursive(int n)
    {
        if (n == 1)
            return 1;
        else
            return n * CalculateFactorialRecursive(n - 1);
        
    }
    // much faster than recursion approach
    public static BigInteger CalculateFactorialIterative(int n)
    {

        BigInteger result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.extraLongFactorials(n);
    }
}
