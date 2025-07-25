using CsvHelper;
using TestProject.Application.Contracts.Infrastructure;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartssExport;
namespace TestProject.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportAutoPartsToCsv(List<AutoPartExportDto> autpartExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(autpartExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
