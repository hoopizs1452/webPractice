using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace A7407630_HW2.Models
{
    public class DeleteExpenseModel
    {
        [DisplayName("酒的種類：")]
        [Required(ErrorMessage = "請選擇酒的種類!")]
        public string delDrink { get; set; }

        public List<String> delTypeList { get; set; }

        [DisplayName("酒的年份：")]
        [Required(ErrorMessage = "請選擇酒的年份!")]
        public string delYear { get; set; }

        public string result { get; set; }
    }
}