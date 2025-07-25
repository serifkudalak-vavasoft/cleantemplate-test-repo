using MediatR;

namespace TestProject.Application.Features.AutoParts.Commands.CreateAutoPart
{
    public class CreateAutoPartCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"AutoPart name: {Name}; Price: {Price}; Description: {Description}";
        }
    }
}
