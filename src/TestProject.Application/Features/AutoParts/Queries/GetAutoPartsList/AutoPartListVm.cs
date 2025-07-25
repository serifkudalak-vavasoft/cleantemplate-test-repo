namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartsList
{
    public class AutoPartListVm
    {
        public Guid AutoPartId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}