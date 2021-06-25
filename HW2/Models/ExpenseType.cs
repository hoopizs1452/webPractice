using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A7407630_HW2.Models
{
    public class ExpenseType
    {
        // 定義消費種類資料表紀錄之欄位名稱與資料型態
        public int id { get; set; }             // 消費種類紀錄之id
        public string expenseType { get; set; } // 消費種類
    }
}