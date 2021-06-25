using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cloudHW03API.Controllers
{
    
    public class FibonacciController : ApiController
    {

        public double fibonacci(double number) //計算費氏數列的function
        {
            return (number == 1 || number == 2) ? 1 : (fibonacci(number - 1) + fibonacci(number - 2));
            //如果n==1或n==2則回傳1，如果不是的話則回傳(n-1)+(n-2)
        }

        [Route("api/Fibonacci/")]//fibonaccicomputepost
        [HttpPost]
        //利用Post呼叫之數學四則運算Web API，輸入參數來自請求(request)本體(body)中之JSON格式資料:
        // 例如: {"number": 10}
        // 使用範例： POST URL: http://.../api/Fibonacci
        // 輸入: {"number":10}
        // 輸出: 55
        public IHttpActionResult ComputePost(NumberInputParams data)
        {
            // accept data in JSON format
            double number = data.number;
            double result;

            // 建立費氏數列計算服務結果物件
            FibonacciResult fibonacciResultobj = new FibonacciResult();

            // 根據number的值進行費氏數列計算
            result = fibonacci(number);

            //=== 並將費氏數列計算服務之運算結果存入費氏數列計算服務結果資料物件對應的欄位 ====
            fibonacciResultobj.Status = "OK";
            fibonacciResultobj.Result = result.ToString();

            // 回傳費氏數列計算服務結果物件，執行環境會因應Client端的請求(利用application/json或application/xml)
            // 分別自動地將物件序列化(Serialize)成JSON或XML字串
            return Ok(fibonacciResultobj);
        }
    }

    // 用來儲存費氏數列計算服務結果的內部類別，
    // 每一個欄位變數名稱將是回傳JSON物件的Key
    public class FibonacciResult
    {
        // 儲存費氏數列計算服務結果之狀態
        public string Status { get; set; }
        // 儲存費氏數列計算服務結果之字串
        public string Result { get; set; }
    }

    public class NumberInputParams
    {
        public double number { get; set; }
    }
}
