using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cloudHW03API.Controllers
{
    public class ConstellationController : ApiController
    {
        [Route("api/constellationcompute/{month}/{day}")]
        [HttpGet]
        // 使用範例： GET  URL: http://.../api/constellationcompute/1/1
        // 輸出: 0.85
        public IHttpActionResult ComputeGet(int month, int day)
        {
            string result;

            // 建立數學服務結果物件
            constellationResult resultobj = new constellationResult();

            // 根據運算子(op)的值進行兩數的數學4則運算
            switch (month)
            {
                case 1:
                    result = (day <= 20) ? "Capricorn" : "Aquarius"; ;
                    break;
                case 2:
                    result = (day <= 18) ? "Aquarius" : "Pisces";
                    break;
                case 3:
                    result = (day <= 18) ? "Pisces" : "Aries";
                    break;
                case 4:
                    result = (day <= 20) ? "Aries" : "Taurus";
                    break;
                case 5:
                    result = (day <= 21) ? "Taurus" : "Gemini";
                    break;
                case 6:
                    result = (day <= 21) ? "Gemini" : "Cancer";
                    break;
                case 7:
                    result = (day <= 22) ? "Cancer" : "Leo";
                    break;
                case 8:
                    result = (day <= 23) ? "Leo" : "Virgo";
                    break;
                case 9:
                    result = (day <= 23) ? "Virgo" : "Libra";
                    break;
                case 10:
                    result = (day <= 23) ? "Libra" : "Scorpio";
                    break;
                case 11:
                    result = (day <= 22) ? "Scorpio" : "Sagittarius";
                    break;
                case 12:
                    result = (day <= 21) ? "Sagittarius" : "Capricorn";
                    break;
                default:
                    result = "Capricorn";
                    break;
            }

            //=== 並將樂透服務之運算結果存入記帳簿服務結果資料物件對應的欄位 ====
            resultobj.Status = "OK";
            resultobj.Result = result;

            // 回傳數學服務結果物件，執行環境會因應Client端的請求(利用application/json或application/xml)
            // 分別自動地將物件序列化(Serialize)成JSON或XML字串
            return Ok(resultobj);
        }
    }

    // 用來儲存數學服務結果的內部類別，
    // 每一個欄位變數名稱將是回傳JSON物件的Key
    public class constellationResult
        {
        // 儲存數學服務結果之狀態
        public string Status { get; set; }
        // 儲存數學服務結果之字串
        public string Result { get; set; }
    }

    public class DateInputParams
    {
        public int month { get; set; }
        public int day { get; set; }
    }
}
