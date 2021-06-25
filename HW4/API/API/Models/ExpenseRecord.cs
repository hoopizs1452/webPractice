using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("HW4_ExpenseRecords")]
    public class ExpenseRecord
    {   // 定義酒櫃資料表紀錄之欄位名稱與資料型態
        public int id { get; set; }             // 酒的id
        public string expenseType { get; set; } // 酒的種類
        public string year { get; set; }     // 酒的年份
    }
}