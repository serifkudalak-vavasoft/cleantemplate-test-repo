using System.Collections.Generic;
namespace TestProject.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportAutoPartsToCsv(List<string> items);
    }
}
