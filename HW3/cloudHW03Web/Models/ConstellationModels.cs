using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cloudHW03Web.Models
{
    public class ConstellationModels
    {
        [DisplayName("月份：")]
        [Required(ErrorMessage = "請輸入月份")]
        public double Month { get; set; }

        [DisplayName("日期：")]
        [Required(ErrorMessage = "請輸入日期")]
        public double Day { get; set; }

        [DisplayName("結果：")]
        public string Result { get; set; }
    }
}