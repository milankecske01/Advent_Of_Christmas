StreamReader f = new StreamReader("input.txt");
string instructions = f.ReadLine();
f.ReadLine();
Dictionary<string, string[]> maps = new Dictionary<string, string[]>();
List<int> pathLengths = new List<int>();

while (!f.EndOfStream)
{
    string line = f.ReadLine();
    string location = line.Substring(0, 3);
    maps[location] = new string[] { line.Substring(7, 3), line.Substring(12, 3) };
}f.Close();
foreach (var map in maps)
{
    string location = map.Key;
    if (location[2] == 'A')
    {
        int length = 0;
        int i = 0;
        while (location[2] != 'Z')
        {
            if (instructions[i] == 'L')
            {
                location = maps[location][0];
            }
            else
            {
                location = maps[location][1];
            }
            i++;
            if (i == instructions.Length)
            {
                i = 0;
            }
            length++;
        }
        pathLengths.Add(length);
    }
}
//LKKT számolás
Dictionary<int, int> primes = new Dictionary<int, int>();
foreach (var szám in pathLengths)
{
    int számCopy = szám;
    Console.WriteLine(szám+":");
    for (int i = 2; számCopy > 1; i++)
    {
        if (számCopy % i == 0)
        {
            int x = 0;
            while (számCopy % i == 0)
            {
                számCopy /= i;
                x++;
            }
            if (primes.ContainsKey(i) && primes[i]<x)
            {
                primes[i] = x;
            }
            else
            {
                primes[i] = x;
            }
            Console.WriteLine($"{i} is a prime factor {x} times!");
        }
    }
}
ulong output = 1;
foreach (var prime in primes)
{
    for (int i = 0; i < prime.Value; i++)
    {
        output *= (ulong)prime.Key;
    }
}
Console.WriteLine($"Answer: {output}");