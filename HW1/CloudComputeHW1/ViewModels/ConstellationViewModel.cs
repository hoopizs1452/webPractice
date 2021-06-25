using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudComputeHW1.ViewModels
{
    public class ConstellationViewModel
    {
        [DisplayName("月份1~12:")]
        [Required(ErrorMessage = "請輸入數字1~12")] //月份的輸入框文字及輸入錯誤時會顯示的資訊
        public double Month { get; set; }

        [DisplayName("日期1~31:")]
        [Required(ErrorMessage = "請輸入數字1~31")] //日期的輸入框文字及輸入錯誤時會顯示的資訊
        public double Date { get; set; }

        [DisplayName("結果:")]
        public string Result { get; set; } //結果的輸入框文字
    }
}