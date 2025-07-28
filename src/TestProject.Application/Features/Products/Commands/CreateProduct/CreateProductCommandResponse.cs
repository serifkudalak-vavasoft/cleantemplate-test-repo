using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Responses;

namespace TestProject.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse<CreateProductDto>
    {
        public CreateProductCommandResponse() : base()
        {
            
        }

        public CreateProductDto Product { get; set; } = default!;
    }
}
