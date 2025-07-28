using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Responses;

namespace TestProject.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandResponse : BaseResponse<UpdateProductDto>
    {
        public UpdateProductCommandResponse() : base()
        {
            
        }

        public UpdateProductDto Product { get; set; }
    }
}
