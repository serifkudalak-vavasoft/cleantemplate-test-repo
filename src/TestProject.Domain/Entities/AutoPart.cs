using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Common;

namespace TestProject.Domain.Entities;

public class AutoPart : AuditableEntity
{
    public Guid AutoPartId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Guid CategoryId { get; set; }

    public Category Category { get; set; }
}