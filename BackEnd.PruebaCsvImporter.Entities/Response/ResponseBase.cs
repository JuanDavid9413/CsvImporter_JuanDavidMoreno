using System.Net;

namespace BackEnd.PruebaCsvImporter.Entities.Response
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            Message = "";
            Code = (int)HttpStatusCode.OK;
        }

        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
