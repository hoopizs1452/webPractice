using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace API.Models
{
    public class DrinkDBContext:DbContext
    {
        public DrinkDBContext() : base("name=HW4DB")
        {
            Database.SetInitializer<DrinkDBContext>(new DropCreateDatabaseIfModelChanges<DrinkDBContext>());
        }
        // 可透過此屬性來存取(Access)ExpenseRecords資料表，資料表中每一筆紀錄對應到ExpenseRecord類別建立的物件
        public DbSet<API.Models.ExpenseRecord> ExpenseRecords { get; set; }
        // 可透過此屬性來存取(Access)ExpenseTypes資料表，資料表中每一筆紀錄對應到ExpenseType類別建立的物件
        public DbSet<API.Models.ExpenseType> types { get; set; }
    }
}