using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("HW4_ExpenseTypes")]
    public class ExpenseType
    {
        // 定義酒的種類資料表紀錄之欄位名稱與資料型態
        public int id { get; set; }             // 酒的種類紀錄之id
        public string expenseType { get; set; } // 酒的種類
    }
}