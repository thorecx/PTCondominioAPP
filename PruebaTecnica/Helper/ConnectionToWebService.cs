using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace PruebaTecnica.Helper
{
    public class ConnectionToWebService : IConnectionWebApi
    {
        public async Task<List<T>> HttpGetAll<T>(string url, string method)
        {
            var httpUrl = "https://localhost:44322/api/" + url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpUrl);
            request.Method = method.ToUpper();
            request.ContentType = "application/json";
            var response = (HttpWebResponse)request.GetResponse();
            var newStream = response.GetResponseStream();
            var sr = new StreamReader(newStream);
            var result = await sr.ReadToEndAsync();
            return JsonConvert.DeserializeObject<List<T>>(result);
        }

        public async Task<T> HttpGetBy<T>(string url, string method)
        {
            var httpUrl = "https://localhost:44322/api/" + url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpUrl);
            request.Method = method.ToUpper();
            request.ContentType = "application/json";
            var response = (HttpWebResponse)request.GetResponse();
            var newStream = response.GetResponseStream();
            var sr = new StreamReader(newStream);
            var result = await sr.ReadToEndAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task HttpPost<T>(string url, object requestModel, string method)
        {
            var httpUrl = "https://localhost:44322/api/" + url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpUrl);
            request.Method = method.ToUpper();
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                string json = JsonConvert.SerializeObject(requestModel);
                sw.Write(json);
                sw.Flush();
            }

            var response = (HttpWebResponse)request.GetResponse();
            var newStream = response.GetResponseStream();
            var sr = new StreamReader(newStream);
            var result = await sr.ReadToEndAsync();
        }

    }
}