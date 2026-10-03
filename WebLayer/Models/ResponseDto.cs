namespace WebLayer.Models
{
    public class ResponseDto
    {
        public ResponseDto()
        {

        }

        public bool IsSuccess { get; set; }
        public BaseError? Error { get; set; }

        public static ResponseDto Success()
        {
            return new ResponseDto
            {
                IsSuccess = true
            };
        }

        public static ResponseDto Failure(string code, string message)
        {
            return new ResponseDto
            {
                IsSuccess = false,
                Error = new BaseError { Code = code, Message = message }
            };
        }
    }
}
