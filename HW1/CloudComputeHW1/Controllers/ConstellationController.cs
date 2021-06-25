using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudComputeHW1.ViewModels;

namespace CloudComputeHW1.Controllers
{
    public class ConstellationController : Controller
    {
        // GET: Constellation
        public ActionResult Constellation()
        {
            return View();
        }

        public string Check(double m, double d) //查詢星座的function, 設定月份為m, 日期為d
        {
			if (m == 1) //如果月份為1
			{
				return (d <= 20) ? "Capricorn" : "Aquarius"; 
				//且日期小於等於20則回傳"Capricorn"，如果不是的話(>= 21)則回傳"Aquarius"
			}
			else if (m == 2) //如果月份為2
			{
				return (d <= 18) ? "Aquarius" : "Pisces";
				//且日期小於等於18則回傳"Aquarius"，如果不是的話(>= 19)則回傳"Pisces"
			}
			else if (m == 3) //如果月份為3
			{
				return (d <= 18) ? "Pisces" : "Aries";
				//且日期小於等於20則回傳"Pisces"，如果不是的話(>= 21)則回傳"Aries"
			}
			else if (m == 4) //如果月份為4
			{
				return (d <= 20) ? "Aries" : "Taurus";
				//且日期小於等於20則回傳"Aries"，如果不是的話(>= 21)則回傳"Taurus"
			}
			else if (m == 5) //如果月份為5
			{
				return (d <= 21) ? "Taurus" : "Gemini";
				//且日期小於等於21則回傳"Taurus"，如果不是的話(>= 22)則回傳"Gemini"
			}
			else if (m == 6) //如果月份為6
			{
				return (d <= 21) ? "Gemini" : "Cancer";
				//且日期小於等於21則回傳"Gemini"，如果不是的話(>= 22)則回傳"Cancer"
			}
			else if (m == 7) //如果月份為7
			{
				return (d <= 22) ? "Cancer" : "Leo";
				//且日期小於等於22則回傳"Cancer"，如果不是的話(>= 23)則回傳"Leo"
			}
			else if (m == 8) //如果月份為8
			{
				return (d <= 23) ? "Leo" : "Virgo";
				//且日期小於等於23則回傳"Leo"，如果不是的話(>= 24)則回傳"Virgo"
			}
			else if (m == 9) //如果月份為9
			{
				return (d <= 23) ? "Virgo" : "Libra";
				//且日期小於等於23則回傳"Virgo"，如果不是的話(>= 24)則回傳"Libra"
			}
			else if (m == 10) //如果月份為10
			{
				return (d <= 23) ? "Libra" : "Scorpio";
				//且日期小於等於23則回傳"Libra"，如果不是的話(>= 24)則回傳"Scorpio"
			}
			else if (m == 11) //如果月份為11
			{
				return (d <= 22) ? "Scorpio" : "Sagittarius";
				//且日期小於等於22則回傳"Scorpio"，如果不是的話(>= 23)則回傳"Sagittarius"
			}
			else if (m == 12) //如果月份為12
			{
				return (d <= 21) ? "Sagittarius" : "Capricorn";
				//且日期小於等於21則回傳"Sagittarius"，如果不是的話(>= 22)則回傳"Capricorn"
			}
			return " ";
		}

		[HttpPost]
		public ActionResult Constellation([Bind(Include = "Month, Date")] ConstellationViewModel mathdata, string btnCompute)
		{
			if (!ModelState.IsValid)
			{
				return View(mathdata);
			}
			try
			{
				double month, date;
				string result;
				month = mathdata.Month;
				date = mathdata.Date;
				switch (btnCompute) //偵測按鈕
				{
					case "查詢":
						result = Check(month, date); //將輸入的月份、日期丟到查詢星座的function裡
						break;
                    default:
                        result = "0";
                        break;
                }

				mathdata.Result = result.ToString(); //將回傳的星座顯示在結果欄上
				return View(mathdata);
			}
			catch (Exception ex)
			{
				string str = "數學運算時發生例外,原因如下:\n" + ex.Message;
				mathdata.Result = str;
				return View(mathdata);
			}
		}
	}
}