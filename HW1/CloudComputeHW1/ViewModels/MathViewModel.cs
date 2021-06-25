using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudComputeHW1.ViewModels
{
    public class MathViewModel
    {
        [DisplayName("數字1:")]
        [Required(ErrorMessage ="請輸入數字1")] //數字的輸入框文字及輸入錯誤時會顯示的資訊
        public double Num1 { get; set; }

        [DisplayName("結果:")]
        public string Result { get; set; } //結果的顯示框文字
    }
}