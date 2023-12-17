string input = "Time:        60     80     86     76\r\nDistance:   601   1163   1559   1300";
//string input = "Time: 7 \r\nDistance: 9";//test
input= input.Replace("\r", "");
List<int> times=new List<int>();
List<int> distances=new List<int>();
bool timesdone=false;
foreach (var data in input.Split("\n"))
{
    string[] line=data.Split(" ").Where(x => x!="").ToArray();
    for (int i = 1; i < line.Length; i++)
    {
        if (timesdone)
        {
            distances.Add(int.Parse(line[i]));
        }
        else
        {
            times.Add(int.Parse(line[i]));
        }
    }
    timesdone = true;
}
int output = 1;
for (int i = 0; i < times.Count; i++)
{
    int time = times[i];
    int distance = distances[i];
    int lowerBound = GetLowerBound(time, distance);
    //Console.WriteLine(GetBounds(time, distance)[0]);
    output *= (time - lowerBound*2 + 1);
    Console.WriteLine($"Time: {time}\n" +
    $"Distance: {distance}\n" +
    $"Lower Bound: {lowerBound}\n" +
    $"Upper Bound: {time - lowerBound}\n" +
    $"Solutions: {time - lowerBound * 2 + 1}\n" +
    $"Output: {output}\n");
}
Console.WriteLine($"Answer: {output}");

int GetLowerBound(int time,int distance) {
    // -time held^2 + time*time held - distance (másodfokú) = 0
    double deviant=(time*time)-4*-1*(-distance);
    //Console.WriteLine(deviant);
    if (deviant<0)
    {
        throw new Exception("deviáns < 0");
    }
    //Console.WriteLine(values[0]);
    double value = (-time + Math.Sqrt(deviant)) / -2;
    if (value%1==0)
    {
        return (int)value+1;
    }
    return (int)Math.Ceiling((-time + Math.Sqrt(deviant)) / -2);
}