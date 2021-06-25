using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Data.Entity;

namespace A7407630_HW2.Models
{
    public class DrinkDBContext:DbContext
    {
        public DrinkDBContext() : base("name=DrinkDB")
        {
            Database.SetInitializer<DrinkDBContext>(new DropCreateDatabaseIfModelChanges<DrinkDBContext>());
        }
        // 可透過此屬性來存取(Access)ExpenseRecords資料表，資料表中每一筆紀錄對應到ExpenseRecord類別建立的物件
        public DbSet<A7407630_HW2.Models.ExpenseRecord> ExpenseRecords { get; set; }
        // 可透過此屬性來存取(Access)ExpenseTypes資料表，資料表中每一筆紀錄對應到ExpenseType類別建立的物件
        public DbSet<A7407630_HW2.Models.ExpenseType>types { get; set; }
    }
}