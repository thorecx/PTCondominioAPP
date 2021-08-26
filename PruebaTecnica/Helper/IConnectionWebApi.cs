using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.Helper
{
    public interface IConnectionWebApi
    {
        Task HttpPost<T>(string url, object requestModel, string method);
        Task<List<T>> HttpGetAll<T>(string url, string method);
        Task<T> HttpGetBy<T>(string url, string method);
    }
}