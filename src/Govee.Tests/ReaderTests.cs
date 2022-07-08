namespace Govee.Tests;

public class Tests
{
    [Test]
    public void Test_SampleData_CanBeRead()
    {
        string filePath = SampleData.CsvFile;
        var r = Core.DataFile.GetReadings(filePath);
        Assert.That(r.Length, Is.GreaterThan(999));
    }
}