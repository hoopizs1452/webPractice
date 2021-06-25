using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cloudHW03Web.Models
{
    public class FibonacciModels
    {
        [DisplayName("數字：")]
        [Required(ErrorMessage = "請輸入數字")]
        public double Number { get; set; }

        [DisplayName("結果：")]
        public string Result { get; set; }
    }
}