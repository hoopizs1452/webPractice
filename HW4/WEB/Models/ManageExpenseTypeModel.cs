using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class ManageExpenseTypeModel
    {
        [DisplayName("輸入新的消費種類：")]
        [Required(ErrorMessage = "請輸入消費種類!")]
        public string expenseType { get; set; }

        [DisplayName("輸入消費種類編號：")]
        [Required(ErrorMessage = "請輸入消費種類編號!")]
        public string expenseTypeNumber { get; set; }

        public string result { get; set; }
    }
}