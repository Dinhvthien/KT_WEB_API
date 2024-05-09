namespace KT_WEB_API.Payloads.Responses
{
    public class ResponseThemdonhang
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public ResponseThemdonhang() { }
        public ResponseThemdonhang(int status, string message)
        {
            Status = status;
            Message = message;
        }
        public ResponseThemdonhang ResponseSuccses(string message)
        {
            return new ResponseThemdonhang(StatusCodes.Status200OK, message);
        }

        public ResponseThemdonhang ResponseError(int status, string message)
        {
            return new ResponseThemdonhang(status, message);
        }
    }
}
