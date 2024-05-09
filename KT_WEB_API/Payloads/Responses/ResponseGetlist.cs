namespace KT_WEB_API.Payloads.Responses
{
    public class ResponseGetlist<T>
    {
        public T Data { get; set; }
        public ResponseGetlist() { }
        public ResponseGetlist(T data)
        {
            Data = data;
        }
        public ResponseGetlist<T> ResponseSuccses(T data)
        {
            return new ResponseGetlist<T>(data);
        }

        public ResponseGetlist<T> ResponseError(T data)
        {
            return new ResponseGetlist<T>(data);
        }
    }
 }
