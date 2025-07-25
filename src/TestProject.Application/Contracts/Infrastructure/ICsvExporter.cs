using System.Collections.Generic;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartssExport;
namespace TestProject.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportAutoPartsToCsv(List<AutoPartExportDto> autopartExportDtos);
    }
}
