namespace XMCore.API.Reponses
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            IsSuccess = false;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
