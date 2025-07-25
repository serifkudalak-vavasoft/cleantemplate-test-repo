using CsvHelper;
using TestProject.Application.Contracts.Infrastructure;
namespace TestProject.Infrastructure.FileExport
{
        public class CsvExporter : ICsvExporter
    {
        public byte[] ExportAutoPartsToCsv(List<string> items)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(items);
            }

            return memoryStream.ToArray();
        }
    }
}
