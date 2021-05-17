using BackEnd.PruebaCsvImporter.Entities.Response;
using System.Net;

namespace BackEnd.PruebaCsvImporter.Utilities
{
    public static class GenericUtility
    {
        public static void ResponseBaseCatch<T>(this ResponseBase<T> data, bool validation, string message, HttpStatusCode code)
        {
            ResponseBase<T> result = data;
            if (validation)
            {
                result.Code = (int)code;
                result.Message = message;
            }
        }
    }
}
