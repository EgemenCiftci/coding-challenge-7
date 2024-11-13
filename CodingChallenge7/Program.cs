using CodingChallenge7;
using System.Numerics;

Console.WriteLine("Started...");

KnightDialer knightDialer = new();

List<(int x, BigInteger)> values = Enumerable.Range(0, 5000)
    .Select(x => (x, knightDialer.CountDistinctNumbers(x)))
    .ToList();

var output = string.Join(Environment.NewLine, values.Select(x => $"{x.x:0000} => {x.Item2}"));
Console.WriteLine(output);

Console.WriteLine("Finished.");

Console.ReadKey();
