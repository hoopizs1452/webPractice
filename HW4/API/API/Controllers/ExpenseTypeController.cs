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
    public class ExpenseTypeController : ApiController
    {
        // 宣告儲存ExpenseTypeController回傳結果之物件變數
        ExpenseTypeControllerResult expenseTypeControllerResultObj;

        // 建立存取資料庫的DbContext物件
        private DrinkDBContext db = new DrinkDBContext();

        // ExpenseTypeController類別的建構子(Constructor)
        public ExpenseTypeController()
        {
            // 若消費種類資料表(ExpenseTypes)沒有任何紀錄，
            // 則將9個預先設好的消費種類存入消費種類資料表中
            try
            {
                //初始消費種類陣列
                string[] initialExpenseTypes =
                      { "白蘭地", "威士忌", "伏特加", "龍舌蘭酒", "朗姆酒", "琴酒", "力嬌酒", "葡萄酒", "清酒" };
                ExpenseType expenseType = new ExpenseType();
                IEnumerable<ExpenseType> expenseTypes = db.types;

                int rowcount = expenseTypes.Count<ExpenseType>();     //計算資料庫資料筆數
                if (rowcount == 0)
                { //若沒有任何消費種類，則利用迴圈方式，將初始消費種類逐一存到ExpenseTypes資料表中
                    for (int i = 0; i < initialExpenseTypes.Length; i++)
                    {
                        expenseType.expenseType = initialExpenseTypes[i];
                        db.types.Add(expenseType);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        // 從ExpeneTypes資料表中取出所有消費種類的方法，回傳資料型態為ExpenseType之列舉集合(陣列)
        // GET: api/ExpenseTypes 
        [HttpGet]
        [Route("api/WineCupboard")]
        public IHttpActionResult GetExpenseTypes()
        {
            try
            {
                return Ok(db.types);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // 從ExpeneTypes資料表中取出所有消費種類的方法，回傳資料型態為加上說明的字串
        // GET: api/ExpenseTypes/string
        [HttpGet]
        [Route("api/WineCupboard/string")]
        public IHttpActionResult GetExpenseTypesString()
        {
            // 建立儲存ExpenseRecordController回傳結果之物件
            expenseTypeControllerResultObj = new ExpenseTypeControllerResult();

            string str = "";
            try
            {
                // 使用LINQ語法取出所有消費種類，並依照id排序
                var result = from a in db.types
                             orderby a.id
                             select a;

                // 利用迴圈逐一讀取每一筆紀錄
                var i = 0;
                foreach (var record in result)
                {
                    str += string.Format("{0:d2}  ", (i + 1)); // 串接記錄編號(索引值+1)
                    str += string.Format("{0}", record.expenseType);//串接price欄位值(消費金額)
                    str += "\n";
                    i++;
                }
                //
                expenseTypeControllerResultObj.Status = "OK";
                expenseTypeControllerResultObj.Result = str;
                return Ok(expenseTypeControllerResultObj);
            }
            catch (Exception ex)
            {
                expenseTypeControllerResultObj.Status = "Exception";
                expenseTypeControllerResultObj.Result = "取出消費種類時發生例外，原因如下： " + ex.Message;
                return Ok(expenseTypeControllerResultObj);

            }

        }

        // 新增消費種類的方法
        // POST: api/ExpenseTypes
        [HttpPost]
        [Route("api/AddDrink/Type")]
        public IHttpActionResult PostExpenseType(ExpenseType expenseType)
        {
            // 建立儲存ExpenseRecordController回傳結果之物件
            expenseTypeControllerResultObj = new ExpenseTypeControllerResult();

            string str = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // 檢驗擬新增的酒的種類是否已存在
                var result = db.types.Where(x => x.expenseType == expenseType.expenseType);
                int count = result.Count(); // 取得記錄數
                if (count == 0)
                { // 如果記錄數為0，表示該新的酒的種類不存在，則可將其新增至ExpenseTypes資料表中
                    db.types.Add(expenseType); // 新增酒的種類
                    db.SaveChanges();                 // 更新至資料庫

                    // 利用LINQ語法取出所有的酒櫃種類紀錄
                    var result1 = from a in db.types
                                  orderby a.id
                                  select a;

                    // 利用迴圈逐一讀取每一筆紀錄，並加入編號說明
                    var i = 0;
                    foreach (var record in result1)
                    {
                        str += string.Format("{0:d2}  ", (i + 1)); // 串接記錄編號(索引值+1)
                        str += string.Format("{0}", record.expenseType);//串接price欄位值(消費金額)
                        str += "\n";
                        i++;
                    }
                    //
                    expenseTypeControllerResultObj.Status = "OK";
                    expenseTypeControllerResultObj.Result = str;
                    return Ok(expenseTypeControllerResultObj);
                }
                else
                {
                    expenseTypeControllerResultObj.Status = "OK";
                    expenseTypeControllerResultObj.Result = "消費種類：【" + expenseType.expenseType + "】已經存在，請重新輸入!";
                    return Ok(expenseTypeControllerResultObj);
                }
            }
            catch (Exception ex)
            {
                expenseTypeControllerResultObj.Status = "Exception";
                expenseTypeControllerResultObj.Result = "儲存消費種類時發生例外，原因如下： " + ex.Message;
                return Ok(expenseTypeControllerResultObj);
            }
        }

        //刪除指定編號的消費種類之方法
        // DELETE: api/ExpenseTypes/delete/{no}
        [HttpGet]
        [Route("api/WineCupboard/delete/{no}")]
        public IHttpActionResult DeleteExpenseType(int no)
        {
            // 建立儲存ExpenseRecordController回傳結果之物件
            expenseTypeControllerResultObj = new ExpenseTypeControllerResult();

            try
            {
                string str = "";
                // 利用LINQ語法取出所有的消費種類紀錄
                var result = from a in db.types
                             orderby a.id
                             select a;

                int count = result.Count(); // 取出記錄數

                // 輸入的編號不在範圍內，則回傳提示訊息
                if ((no < 1) || (no > count))
                {
                    expenseTypeControllerResultObj.Status = "OK";
                    expenseTypeControllerResultObj.Result = "輸入的編號不在範圍內，請重新輸入!";
                    return Ok(expenseTypeControllerResultObj);
                }
                else
                {
                    var record = result.ToArray<ExpenseType>()[no - 1]; //找出指定編號那筆紀錄
                    db.types.Remove(record); // //將指定編號那筆紀錄刪除
                    db.SaveChanges(); // 更新資料庫

                    // 取出最新所有的消費種類
                    var result1 = from a in db.types
                                  orderby a.id
                                  select a;

                    // 利用迴圈逐一讀取每一筆紀錄
                    var i = 0;
                    foreach (var record1 in result1)
                    {
                        str += string.Format("{0:d2}  ", (i + 1)); // 串接記錄編號(索引值+1)
                        str += string.Format("{0}", record1.expenseType);//串接price欄位值(消費金額)
                        str += "\n";
                        i++;
                    }
                    //
                    expenseTypeControllerResultObj.Status = "OK";
                    expenseTypeControllerResultObj.Result = str;
                    return Ok(expenseTypeControllerResultObj);
                }
            }
            catch (Exception ex)
            {
                expenseTypeControllerResultObj.Status = "Exception";
                expenseTypeControllerResultObj.Result = "刪除消費種類時發生例外，原因如下： " + ex.Message;
                return Ok(expenseTypeControllerResultObj);
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

        private bool ExpenseTypeExists(int id)
        {
            return db.types.Count(e => e.id == id) > 0;
        }

        // 用來儲存ExpenseTypeController回傳結果的內部類別
        public class ExpenseTypeControllerResult
        {
            // 紀錄ExpenseTypeController之回傳結果狀態
            public string Status { get; set; }
            // 儲存ExpenseRecordController回傳結果字串
            public string Result { get; set; }
        }
    }
}
