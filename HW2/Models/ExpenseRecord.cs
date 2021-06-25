using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A7407630_HW2.Models
{
    public class ExpenseRecord
    {   // 定義記帳簿資料表紀錄之欄位名稱與資料型態
        public int id { get; set; }             // 酒的id
        public string expenseType { get; set; } // 酒的種類
        public string year { get; set; }     // 酒的年份
    }
}