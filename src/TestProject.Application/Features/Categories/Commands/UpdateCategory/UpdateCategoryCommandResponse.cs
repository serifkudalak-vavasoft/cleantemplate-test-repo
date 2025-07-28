using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Responses;

namespace TestProject.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse : BaseResponse<UpdateCategoryDto>
    {
        public UpdateCategoryCommandResponse() : base()
        {
            
        }

        public UpdateCategoryDto Category { get; set; }
    }
}
