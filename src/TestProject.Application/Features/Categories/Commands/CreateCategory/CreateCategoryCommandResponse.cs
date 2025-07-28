using TestProject.Application.Responses;

namespace TestProject.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse<CreateCategoryDto>
    {
        public CreateCategoryCommandResponse() : base()
        {
            
        }

        public CreateCategoryDto Category { get; set; } = default!;
    }
}