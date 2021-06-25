using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http; // needed for using the HttpClient class
using System.Net.Http.Headers;
using System.Threading.Tasks;

using cloudHW03Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace cloudHW03Web.Controllers
{
    public class FibonacciController : Controller
    {
        readonly string baseurl = WebApiConfig.baseurl;

        // GET: URL: http://.../Fibonacci/fibonacciPost
        public ActionResult FibonacciPost()
        {
            return View();
        }

        [HttpPost]
        // 只要自動繫結模型中的number
        public async Task<ActionResult> fibonacciPost([Bind(Include = "Number")] FibonacciModels mathdata, string btnCompute)
        {
            if (!ModelState.IsValid)
            {
                return View(mathdata);
            }
            try
            {
                string urlstring = baseurl + "api/Fibonacci/";//FibonacciPost
                //建立HttClient物件
                HttpClient client = new HttpClient();
                // // 建立JSON格式之請求內容字串
                RequestDataForFibonacciComputePost requestData = new RequestDataForFibonacciComputePost();
                requestData.number = mathdata.Number;
                string jsonString = JsonConvert.SerializeObject(requestData);
                // 建立傳遞內容HttpContent物件
                HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                // 以非同步POST方式呼叫數學服務之Web API
                var response = await client.PostAsync(urlstring, httpContent);
                // 以非同步方式取出回傳結果之JSON格式字串
                string result = await response.Content.ReadAsStringAsync();
                // 將JSON格式字串轉換成.NET的JSON物件
                dynamic jsonObject = JsonConvert.DeserializeObject(result);
                // 從JSON物件中取出Result的值，存入mathdata物件的Result欄位
                mathdata.Result = jsonObject.Result;
                // 將mathdata物件傳送到View顯示
                return View(mathdata);
            }
            catch (Exception ex)
            {
                mathdata.Result = "費氏數列運算時發生例外，原因如下: " + ex.Message;
                // 將mathdata物件傳送到View顯示
                return View(mathdata);
            }

        }
    }

    public class RequestDataForFibonacciComputePost
    {
        public double number { get; set; }
    }
}