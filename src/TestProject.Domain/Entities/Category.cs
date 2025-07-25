
using TestProject.Domain.Common;

namespace TestProject.Domain.Entities
{
    public class Category: AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
       public ICollection<AutoPart> AutoParts { get; set; }
    }
}
