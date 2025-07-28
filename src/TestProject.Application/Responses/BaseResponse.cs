namespace TestProject.Application.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(T data, string message = "İşlem başarılı")
        {
            Success = true;
            Message = message;
            Data = data;
        }

        public static BaseResponse<T> Fail(string message, List<string>? errors = null)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = message,
                ValidationErrors = errors
            };
        }

        public static BaseResponse<T> SuccessResponse(T data, string message = "İşlem başarılı")
        {
            return new BaseResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? ValidationErrors { get; set; }
    }
}
