using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CloudComputeHW1.ViewModels;

namespace CloudComputeHW1.Controllers
{
    public class MathController : Controller
    {
        // GET: Math
        public ActionResult MathCompute()
        {
            return View();
        }

        public double fibonacci(double n) //計算費氏數列的function
        {
            return (n == 1 || n == 2) ? 1 : (fibonacci(n - 1) + fibonacci(n - 2));
            //如果n==1或n==2則回傳1，如果不是的話則回傳(n-1)+(n-2)
        }

        [HttpPost]
        public ActionResult MathCompute([Bind(Include = "Num1")] MathViewModel mathdata, string btnCompute)
        {
            if (!ModelState.IsValid)
            {
                return View(mathdata);
            }
            try
            {
                double num1, result;
                num1 = mathdata.Num1;
                switch (btnCompute) //偵測按鈕
                {
                    case "計算":
                        result = fibonacci(num1); //將輸入的值丟到費氏數列的function裡
                        break;
                    default:
                        result = 0;
                        break;
                }

                mathdata.Result = result.ToString(); //將回傳的數值顯示於結果欄上
                return View(mathdata);
            }
            catch(Exception ex)
            {
                string str = "數學運算時發生例外,原因如下:\n" + ex.Message;
                mathdata.Result = str;
                return View(mathdata);
            }
        }
    }
}