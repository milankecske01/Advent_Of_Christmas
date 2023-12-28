StreamReader f = new StreamReader("input.txt");
long output = 0;
while (!f.EndOfStream)
{
    List<long[]> arrays = new List<long[]>();
    long[] line = Array.ConvertAll(f.ReadLine().Trim().Split(" "), long.Parse);
    arrays.Add(line);

    int i = 0;
    bool finalLine = true;
    do
    {
        finalLine = true;
        long[] currentArray = new long[line.Length - i - 1];
        long[] watchedArray = arrays.ElementAt(i);
        for (int k = 0; k < watchedArray.Length - 1; k++)
        {
            long current = watchedArray[k + 1] - watchedArray[k];
            currentArray[k] = current;
            if (current != 0)
            {
                finalLine = false;
            }
        }
        i++;
        arrays.Add(currentArray);
    } while (!finalLine);

    long number = 0;
    for (int k = arrays.Count - 1; k > 0; k--)
    {
        number = arrays[k - 1][0]-number;
    }

    output += number;
}
Console.WriteLine(output);