using System;
//
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace A7407630_HW2.Models
{
    public class ManageExpenseTypeModel
    {
        [DisplayName("輸入新的酒種類：")]
        [Required(ErrorMessage = "請輸入酒的種類!")]
        public string manageType { get; set; }

        [DisplayName("輸入酒的種類編號：")]
        [Required(ErrorMessage = "請輸入酒的種類編號!")]
        public string manageTypeNumber { get; set; }

        public string result { get; set; }
    }
}