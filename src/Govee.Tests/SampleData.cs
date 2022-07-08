using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Govee.Tests
{
    internal static class SampleData
    {
        public static string Folder => Path.GetFullPath("../../../../../data/");
        public static string CsvFile => Directory.GetFiles(Folder, "*.csv").First();

        [Test]
        public static void Test_SampleFolder_Exists()
        {
            Assert.That(Directory.Exists(Folder));
        }

        [Test]
        public static void Test_SampleFile_Exists()
        {
            Assert.That(File.Exists(CsvFile));
        }
    }
}
