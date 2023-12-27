#region beolvasás

StreamReader f = new StreamReader("input.txt");
string instructions=f.ReadLine();
f.ReadLine();
Dictionary<string, string[]> maps = new Dictionary<string, string[]>();
string current = "AAA";

while (!f.EndOfStream)
{
    string line= f.ReadLine();
    maps[line.Substring(0, 3)] = new string[] {line.Substring(7,3), line.Substring(12, 3) };
}f.Close();
#endregion

#region feldolgozás

int i = 0;
uint output = 0;
while (current != "ZZZ")
{
    if (instructions[i] == 'L')
    {
        current = maps[current][0];
    }
    else
    {
        current = maps[current][1];
    }
    i++;
    if (i==instructions.Length)
    {
        i = 0;
    }
    Console.WriteLine(current);
    output++;
}
Console.WriteLine(output);
#endregion feldolgozás