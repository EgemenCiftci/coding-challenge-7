using System.Numerics;

namespace CodingChallenge7;

public class KnightDialer
{
    private static readonly Dictionary<int, int[]> knightMoves = new()
    {
        { 0, [ 4, 6 ] },
        { 1, [ 6, 8 ] },
        { 2, [ 7, 9 ] },
        { 3, [4, 8] },
        { 4, [0, 3, 9] },
        { 5, [] },
        { 6, [0, 1, 7] },
        { 7, [2, 6] },
        { 8, [1, 3] },
        { 9, [2, 4] }
    };

    private readonly Dictionary<(int, int), BigInteger> memo = [];

    public BigInteger CountDistinctNumbers(int n)
    {
        if (n == 0)
        {
            return 0;
        }
        else
        {
            BigInteger sum = 0;
            for (int x = 0; x < 10; x++)
            {
                sum += CountDistinctFrom(x, n);
            }
            return sum;
        }
    }

    private BigInteger CountDistinctFrom(int start, int hops)
    {
        if (hops == 1)
        {
            return 1;
        }

        if (!memo.TryGetValue((start, hops), out BigInteger sum))
        {
            foreach (int x in knightMoves[start])
            {
                sum += CountDistinctFrom(x, hops - 1);
            }
            memo[(start, hops)] = sum;
        }

        return sum;
    }
}

