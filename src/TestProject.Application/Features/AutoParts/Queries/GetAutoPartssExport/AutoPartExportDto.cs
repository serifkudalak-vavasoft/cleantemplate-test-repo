namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartssExport
{
    public class AutoPartExportDto
    {
        public Guid AutoPartId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
