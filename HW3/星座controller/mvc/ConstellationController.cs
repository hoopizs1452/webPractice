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
    public class ConstellationController : Controller
    {
        // 由App_Start資料夾中的靜態類別WebApiConfig.cs取出WebApis的基底網址(自己定義的)
        readonly string baseurl = WebApiConfig.baseurl;

        // GET  URL: http://.../math/Constellation
        public ActionResult ConstellationGet()
        {
            return View();
        }

        // POST  URL: http://.../math/mathcompute
        [HttpPost]
        // 只要自動繫結模型中的Month及
        public async Task<ActionResult> ConstellationGet([Bind(Include = "Month, Day")] ConstellationModels mathdata, string btnCompute)
        {
            if (!ModelState.IsValid)
            {
                return View(mathdata);
            }
            try
            {
                string urlstring = baseurl + "api/constellationcompute/" + mathdata.Month + "/" + mathdata.Day;
                //建立HttClient物件
                HttpClient client = new HttpClient();
                // 以非同步GET方式呼叫數學服務之API
                var response = await client.GetAsync(urlstring);
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
                mathdata.Result = "數學運算時發生例外，原因如下: " + ex.Message;
                // 將mathdata物件傳送到View顯示
                return View(mathdata);
            }

        }
    }
    public class RequestDataForConstellationComputePost
    {
        public double month { get; set; }
        public double day { get; set; }
    }
}