namespace Govee.Core;

public struct Reading
{
    public DateTime Timestamp { get; init; }
    public double Tempearture { get; init; }
    public double Humidity { get; init; }
}
