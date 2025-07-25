using System;

namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartDetail;

public class AutoPartDetailVm
{
    public Guid AutoPartId { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public Guid CategoryId { get; set; }

    public CategoryDto Category { get; set; }
}