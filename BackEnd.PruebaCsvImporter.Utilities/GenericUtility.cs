using BackEnd.PruebaCsvImporter.Entities.Response;
using System;
using System.Collections.Generic;
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

        public static IEnumerable<TSource> DistinctBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
