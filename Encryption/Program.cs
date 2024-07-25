using System.Text;

class Result
{

    /*
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {

        var s_ = s.Where(c => !char.IsWhiteSpace(c));

        var sb = new StringBuilder();
        foreach (char c in s_)
        {
            sb.Append(c);
        }

        var lSqr = Math.Sqrt(sb.Length);

        int row = (int)Math.Floor(lSqr);
        int column = (int)Math.Ceiling(lSqr);

        s = sb.ToString();

        var chunks = s.Chunk(column);
        var result = new StringBuilder();
        for (int i = 0; i < column; i++)
        {
            foreach (var item in chunks)
            {
                if (item.Length > i)
                {
                    result.Append(item[i]);
                }
            }
            result.Append(" ");
        }

        return result.ToString();
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        Console.WriteLine(result);
    }
}
