
string input = "Time:        60     80     86     76\r\nDistance:   601   1163   1559   1300";
//string input = "Time: 7 \r\nDistance: 9";//test
input = input.Replace("\r", "");
string[] inputData = input.Split("\n");
string timeData = inputData[0].Replace(" ","");
string distanceData= inputData[1].Replace(" ", "");
long time = long.Parse(timeData.Substring(timeData.IndexOf(":") + 1));
long distance = long.Parse(distanceData.Substring(distanceData.IndexOf(":") + 1));
Console.WriteLine(time - GetLowerBound(time, distance) * 2 + 1);
long GetLowerBound(long time, long distance)
{
    // -time held^2 + time*time held - distance (másodfokú) = 0
    double deviant = (time * time) - 4 * -1 * (-distance);
    //Console.WriteLine(deviant);
    if (deviant < 0)
    {
        throw new Exception("deviáns < 0");
    }
    //Console.WriteLine(values[0]);
    double value = (-time + Math.Sqrt(deviant)) / -2;
    if (value % 1 == 0)
    {
        return (long)value + 1;
    }
    return (long)Math.Ceiling((-time + Math.Sqrt(deviant)) / -2);
}