using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class DeleteExpenseModel
    {
        [DisplayName("酒的品牌：")]
        [Required(ErrorMessage = "請輸入酒的種類!")]
        public string delType { get; set; }

        [DisplayName("酒的年份：")]
        [Required(ErrorMessage = "請選擇酒的年份!")]
        public string year { get; set; }

        public string result { get; set; }
    }
}