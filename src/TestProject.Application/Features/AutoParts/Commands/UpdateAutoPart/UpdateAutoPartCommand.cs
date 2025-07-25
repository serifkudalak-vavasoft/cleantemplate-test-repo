using MediatR;
using System;

namespace TestProject.Application.Features.AutoParts.Commands.UpdateAutoPart
{
    public class UpdateAutoPartCommand : IRequest
    {
        public Guid AutoPartId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
