namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartssExport
{
    public class AutoPartExportFileVm
    {
        public string AutoPartExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}