using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ExpenseRecordController : ApiController
    {
        // 宣告儲存ExpenseRecordController回傳結果之物件變數
        ExpenseRecordControllerResult expenseRecordControllerResultObj;

        // 建立雲端記帳簿服務資料庫的物件，可以存取Talltbooks及ExpenseTypes資料表
        private DrinkDBContext db = new DrinkDBContext();

        // 查詢所選酒的種類，
        // GET: api/QueryWineCupboard/{variety:string}
        [HttpGet]
        [Route("api/WineCupboard/query/{variety}")]
        public IHttpActionResult GetExpenseRecords(string variety)
        {
            // 建立儲存ExpenseRecordController回傳結果之物件
            expenseRecordControllerResultObj = new ExpenseRecordControllerResult();
            
            string str;      //用於紀錄查詢結果字串
            int rowCount;    // 用於儲存紀錄數

            str = "";

            // 使用LINQ語法查詢酒的種類的酒櫃紀錄，並依照酒櫃種類群組，
            // 每種酒櫃種類只取出第1筆紀錄 
            var result = from a in db.ExpenseRecords
                         where ((a.expenseType == variety)/* && (a.year == year)*/)
                         select a;

            var records = result.ToArray<ExpenseRecord>(); // 將結果轉換成酒櫃紀錄陣列
            //
            rowCount = result.Count(); // 取得紀錄數
            if (rowCount == 0)  // 若記錄數為0，則回傳有消費紀錄之訊息
            {
                str = "沒有" + variety + "的紀錄";
                //
                expenseRecordControllerResultObj.Status = "OK";
                expenseRecordControllerResultObj.Result = str;
                return Ok(expenseRecordControllerResultObj);
            }
            else // 
            {
                try
                {
                    str = variety + "之品項統計如下:\n";
                    foreach (var record in records) // 逐一取出消費資料的每一筆紀錄record
                    {
                        // 使用LINQ語法查詢久的種類與record酒櫃種類相同的所有酒櫃紀錄
                        // use LINQ to query data 
                        var result1 = from b in db.ExpenseRecords
                                      where ((b.expenseType == variety)/* && (b.year == year)*/)
                                      select b;
                        str += string.Format("{0} 年份:{1}\n", record.expenseType, record.year);
                    }
                    expenseRecordControllerResultObj.Status = "OK";
                    expenseRecordControllerResultObj.Result = str;
                    return Ok(expenseRecordControllerResultObj);
                }
                catch (Exception ex)
                {
                    expenseRecordControllerResultObj.Status = "Exception";
                    expenseRecordControllerResultObj.Result = "依照消費種類查詢消費紀錄時發生例外，原因如下" + ex.Message;
                    return Ok(expenseRecordControllerResultObj);
                }
            }
        }


        // 新增酒櫃紀錄之方法
        // POST: api/AddDrink
        [HttpPost]
        [Route("api/AddDrink/Record")]
        public IHttpActionResult PostExpenseRecord(ExpenseRecord expenseRecord)
        {
            // 建立儲存ExpenseRecordController回傳結果之物件
            expenseRecordControllerResultObj = new ExpenseRecordControllerResult();

            try
            {
                db.ExpenseRecords.Add(expenseRecord);
                db.SaveChanges();
                string result = "已成功儲存一筆消費紀錄\n";
                //
                expenseRecordControllerResultObj.Status = "OK";
                expenseRecordControllerResultObj.Result = result;
                return Ok(expenseRecordControllerResultObj);
            }
            catch (Exception ex)
            {
                expenseRecordControllerResultObj.Status = "Exception";
                expenseRecordControllerResultObj.Result = "儲存消費紀錄時發生例外，原因如下： " + ex.Message;
                return Ok(expenseRecordControllerResultObj);
            }
        }

        // 刪除酒櫃紀錄之方法
        // DELETE: api/Tallybooks/delete/{variety}/{year}
        [HttpGet]
        [Route("api/WineCupboard/delete/{variety}/{year}")]
        public IHttpActionResult DeleteExpenseRecords(string variety, string year)
        {
            // 建立儲存ExpenseRecordController回傳結果之物件
            expenseRecordControllerResultObj = new ExpenseRecordControllerResult();
            //
            string str = "";

            try
            {
                // 使用 LINQ 取出起訖日期間的消費資料紀錄 (依照消費日期排序)
                var result = from a in db.ExpenseRecords
                             where ((a.expenseType == variety) && (a.year == year))
                             select a;
                int count = result.Count(); // 取得紀錄數
                if (count == 0)  // 若記錄數為0，則回傳有消費紀錄之訊息
                {
                    str = "沒有" + variety + ", 年份:" + year + "的紀錄";
                    //
                    expenseRecordControllerResultObj.Status = "OK";
                    expenseRecordControllerResultObj.Result = str;
                    return Ok(expenseRecordControllerResultObj);
                }

                db.ExpenseRecords.RemoveRange(result); // 從db物件刪除result中的消費資料紀錄
                db.SaveChanges();       // 更新資料庫
                str = "已經成功刪除" + count + "筆紀錄!";
                //
                expenseRecordControllerResultObj.Status = "OK";
                expenseRecordControllerResultObj.Result = str;
                return Ok(expenseRecordControllerResultObj);
            }
            catch (Exception ex)
            {
                expenseRecordControllerResultObj.Status = "Exception";
                expenseRecordControllerResultObj.Result = "刪除消費紀錄時發生例外，原因如下： " + ex.Message;
                return Ok(expenseRecordControllerResultObj);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WineCupboardExists(int id)
        {
            return db.ExpenseRecords.Count(e => e.id == id) > 0;
        }

        // 用來儲存ExpenseRecordController回傳結果的內部類別
        public class ExpenseRecordControllerResult
        {
            // 紀錄ExpenseRecordController之回傳結果狀態
            public string Status { get; set; }
            // 儲存ExpenseRecordController回傳結果字串
            public string Result { get; set; }
        }
    }
}