using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class HttpRequest
    {
        public Observable<string> Get(string url)
        {
            WebRequest request = WebRequest.Create(url);
            // 使用 HttpWebRequest.Create 實際上也是呼叫 WebRequest.Create
            //WebRequest request = HttpWebRequest.Create("http://jsonplaceholder.typicode.com/posts");
            //指定 request 使用的 http verb
            request.Method = "GET";
            Observable<string> observable = null;
            //使用 GetResponse 方法將 request 送出，如果不是用 using 包覆，請記得手動 close WebResponse 物件，避免連線持續被佔用而無法送出新的 request
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            //使用 GetResponseStream 方法從 server 回應中取得資料，stream 必需被關閉
            //使用 stream.close 就可以直接關閉 WebResponse 及 stream，但同時使用 using 或是關閉兩者並不會造成錯誤，養成習慣遇到其他情境時就比較不會出錯
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                observable = new Observable<string>(observer => 
                {
                    observer.Next(result);
                    observer.Complete();
                });
                //result.Dump();
            }
            return observable;
        }
    }
}
