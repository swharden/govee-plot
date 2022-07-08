namespace Govee.Core;

public static class DataFile
{
    public static Reading[] GetReadings(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        List<Reading> readings = new();

        foreach (string line in lines)
        {
            if (line.StartsWith("T") || line.Length < 20)
                continue;

            string[] parts = line.Split(",");
            Reading reading = new()
            {
                Timestamp = DateTime.Parse(parts[0]),
                Tempearture = double.Parse(parts[1]),
                Humidity = double.Parse(parts[2]),
            };

            readings.Add(reading);
        }

        return readings.ToArray();
    }
}
