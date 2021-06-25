using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class QueryExpenseModel
    {
        [DisplayName("酒的品牌：")]
        [Required(ErrorMessage = "請選擇酒的種類!")]
        public string searchType { get; set; }

        public string result { get; set; }
    }
}