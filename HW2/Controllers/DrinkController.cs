using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;        // 使用HttpClient類別所屬的名稱空間
using Newtonsoft.Json;        // 使用JsonConvert類別所屬的名稱空間
using Newtonsoft.Json.Linq;
using System.Threading.Tasks; // 使用Task類別所屬的名稱空間
using System.Text;            // 使用Encoding類別所屬的名稱空間
using A7407630_HW2.Models;

namespace A7407630_HW2.Controllers
{
    public class DrinkController : Controller
    {
        // 建立雲端記帳簿服務資料庫的物件，可以存取Talltbooks及ExpenseTypes資料表
        private DrinkDBContext db = new DrinkDBContext();

        #region DrinkController建構子
        // TallybookController類別的建構子(Constructor)
        public DrinkController()
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
        #endregion

        #region 儲存酒類紀錄
        public ActionResult SaveExpenseIndex()
        {
            // 建立一個SaveExpenseViewModel物件
            SaveExpenseModel saveExpenseViewModel = new SaveExpenseModel();

            try
            {
                // 利用LINQ語法取出所有的消費種類紀錄
                var result = from a in db.types
                             select a;
                // 建立一個字串清單物件expenseTypeList
                List<string> expenseTypeList = new List<string>();
                // 將回傳的消費種類一一取出，然後存入字串清單expenseTypeList
                foreach (var record in result)
                {
                    expenseTypeList.Add(record.expenseType);
                }
                // 將expenseTypeList存入saveExpenseViewModel物件的expenseTypeList屬性中
                saveExpenseViewModel.expenseTypeList = expenseTypeList;

                // 將saveExpenseViewModel物件傳到View Razor Page
                return View(saveExpenseViewModel);
            }
            catch (Exception ex)
            {
                // 使用TempData的Save變數攜帶儲存消費紀錄發生例外的原因字串
                TempData["Save"] = "儲存酒類紀錄時發生例外，原因如下： " + ex.Message;

                // 將{"發生例外!"}字串清單存入saveExpenseViewModel物件的expenseTypeList屬性中
                saveExpenseViewModel.expenseTypeList = new List<string>() { "發生例外!" };

                // 將expenseData物件傳到View Razor Page
                return View(saveExpenseViewModel);
            }
        }

        [HttpPost]
        // 利用Exclude不要自動繫結模型中的result屬性
        public ActionResult SaveExpenseIndex([Bind(Exclude = "result")] SaveExpenseModel expenseData)
        {
            // 建立消費紀錄物件，並存入從前端網頁傳過來的消費紀錄資料
            ExpenseRecord expenseRecord = new ExpenseRecord();
            expenseRecord.expenseType = expenseData.expenseType;
            expenseRecord.year = expenseData.year;

            try
            {
                db.ExpenseRecords.Add(expenseRecord);
                db.SaveChanges();
                // 使用TempData的Save變數攜帶結果字串
                TempData["Save"] = "已成功儲存一筆酒類紀錄!";

                //重新導向儲存消費資料頁面
                return RedirectToAction("SaveExpenseIndex");
            }
            catch (Exception ex)  // 例外處理
            {
                // 使用TempData的Result變數攜帶結果字串
                TempData["Save"] = "儲存酒類紀錄時發生例外，原因如下: " + ex.Message;

                //重新導向儲存消費資料頁面
                return RedirectToAction("SaveExpenseIndex");
            }
        }
        #endregion

        #region 查詢酒類紀錄
        public ActionResult QueryExpenseIndex()
        {
            // 建立一個queryExpenseViewModel物件
            QueryExpenseModel queryExpenseViewModel = new QueryExpenseModel();

            try
            {
                // 利用LINQ語法取出所有的消費種類紀錄
                var result = from a in db.types
                             select a;
                // 建立一個字串清單物件expenseTypeList
                List<string> expenseTypeList = new List<string>();
                // 將回傳的消費種類一一取出，然後存入字串清單expenseTypeList
                foreach (var record in result)
                {
                    expenseTypeList.Add(record.expenseType);
                }
                // 將expenseTypeList存入saveExpenseViewModel物件的expenseTypeList屬性中
                queryExpenseViewModel.searchTypeList = expenseTypeList;

                // 將saveExpenseViewModel物件傳到View Razor Page
                return View(queryExpenseViewModel);
            }
            catch (Exception ex)
            {
                // 使用TempData的Save變數攜帶儲存消費紀錄發生例外的原因字串
                TempData["Query"] = "查詢酒類紀錄時發生例外，原因如下： " + ex.Message;

                // 將{"發生例外!"}字串清單存入saveExpenseViewModel物件的expenseTypeList屬性中
                queryExpenseViewModel.searchTypeList = new List<string>() { "發生例外!" };

                // 將expenseData物件傳到View Razor Page
                return View(queryExpenseViewModel);
            }
        }

        [HttpPost]
        // 利用Exclude不要自動繫結模型中的result屬性
        public ActionResult QueryExpenseIndex([Bind(Exclude = "result")] QueryExpenseModel queryExpenseData)
        {
            // 取出從前端網頁傳過來的起、訖日期及查詢模式
            string searchType = queryExpenseData.searchType;
            //string searchYear = queryExpenseData.searchYear;
            string str;      //用於紀錄查詢結果字串
            int rowCount;    // 用於儲存紀錄數

            try
            {
                str = "";

                // 使用LINQ語法查詢起訖日期間的消費紀錄，並依照消費種類群組，
                // 每種消費種類只取出第1筆紀錄 
                var result = from a in db.ExpenseRecords
                             where ((a.expenseType == searchType))
                             select a;

                var records = result.ToArray<ExpenseRecord>(); // 將結果轉換成消費紀錄陣列

                //
                rowCount = result.Count(); // 取得紀錄數
                if (rowCount == 0)  // 若記錄數為0，則回傳有消費紀錄之訊息
                {
                    str = "沒有" + searchType + "的品項";
                    //
                    TempData["Query"] = str;

                    //重新導向儲存消費資料頁面
                    return RedirectToAction("QueryExpenseIndex");
                }
                else // 
                {
                    str = searchType + "之品項統計如下:\n";
                    foreach (var record in records) // 逐一取出消費資料的每一筆紀錄record
                    {
                        // 使用LINQ語法查詢起訖日期間消費種類與record消費種類相同的所有消費紀錄
                        // use LINQ to query data 
                        var result1 = from b in db.ExpenseRecords
                                      where ((b.expenseType == searchType)/* && (b.year == searchYear)*/)
                                      select b;
                        str += string.Format("{0} 年份:{1}\n", record.expenseType, record.year);
                    }
                    TempData["Query"] = str;

                    //重新導向儲存消費資料頁面
                    return RedirectToAction("QueryExpenseIndex");
                }
            }
            catch (Exception ex)
            {
                TempData["Query"] = "依照消費種類查詢消費紀錄時發生例外，原因如下" + ex.Message;

                //重新導向儲存消費資料頁面
                return RedirectToAction("QueryExpenseIndex");
            }
        }
        #endregion

        #region 刪除酒類紀錄
        public ActionResult DeleteExpenseIndex()
        {
            // 建立一個SaveExpenseViewModel物件
            DeleteExpenseModel delExpenseViewModel = new DeleteExpenseModel();

            try
            {
                // 利用LINQ語法取出所有的消費種類紀錄
                var result = from a in db.types
                             select a;
                // 建立一個字串清單物件expenseTypeList
                List<string> expenseTypeList = new List<string>();
                // 將回傳的消費種類一一取出，然後存入字串清單expenseTypeList
                foreach (var record in result)
                {
                    expenseTypeList.Add(record.expenseType);
                }
                // 將expenseTypeList存入saveExpenseViewModel物件的expenseTypeList屬性中
                delExpenseViewModel.delTypeList = expenseTypeList;

                // 將saveExpenseViewModel物件傳到View Razor Page
                return View(delExpenseViewModel);
            }
            catch (Exception ex)
            {
                // 使用TempData的Save變數攜帶儲存消費紀錄發生例外的原因字串
                TempData["Delete"] = "儲存酒類紀錄時發生例外，原因如下： " + ex.Message;

                // 將{"發生例外!"}字串清單存入saveExpenseViewModel物件的expenseTypeList屬性中
                delExpenseViewModel.delTypeList = new List<string>() { "發生例外!" };

                // 將expenseData物件傳到View Razor Page
                return View(delExpenseViewModel);
            }
        }

        [HttpPost]
        // 利用Exclude不要自動繫結模型中的result屬性
        public ActionResult DeleteExpenseIndex([Bind(Exclude = "result")] DeleteExpenseModel deleteExpenseData)
        {
            ExpenseRecord expenseRecord = new ExpenseRecord();
            expenseRecord.expenseType = deleteExpenseData.delDrink;
            expenseRecord.year = deleteExpenseData.delYear;

            try
            {
                // 取出從前端網頁傳過來的起、訖日期
                string delDrink = deleteExpenseData.delDrink;
                string delYear = deleteExpenseData.delYear;
                string str = "";
                // 使用 LINQ 取出起訖日期間的消費資料紀錄
                var result = from a in db.ExpenseRecords
                             where ((a.expenseType == delDrink) && (a.year == delYear))
                             select a;
                int count = result.Count(); // 取得紀錄數
                if (count == 0)  // 若記錄數為0，則回傳沒有消費紀錄之訊息
                {
                    str = "沒有" + delDrink + ", 年份:" + delYear + "的紀錄";

                    deleteExpenseData.result = str;
                    return View(deleteExpenseData);
                }

                db.ExpenseRecords.RemoveRange(result); // 從db物件刪除result中的消費資料紀錄
                db.SaveChanges();       // 更新資料庫
                //str = "已經成功刪除" + count + "筆紀錄!";

                //
                //deleteExpenseData.result = str;
                //return View(deleteExpenseData);
                TempData["Delete"] = "已成功刪除一筆酒類紀錄!";

                //重新導向儲存消費資料頁面
                return RedirectToAction("DeleteExpenseIndex");
            }
            catch (Exception ex)
            {
                TempData["Delete"] = "刪除消費紀錄時發生例外，原因如下： " + ex.Message;
                return RedirectToAction("DeleteExpenseIndex");
            }
        }
        #endregion

        #region 管理酒的種類
        public ActionResult ManageExpenseTypeIndex()
        {
            // 建立一個ManageExpenseTypeViewModel物件
            ManageExpenseTypeModel manageExpenseTypeData = new ManageExpenseTypeModel();

            string str = ""; // 用於儲存結果之字串變數
            try
            {
                // 使用LINQ語法取出所有消費種類，並依照id排序
                var result = from a in db.types
                             orderby a.id
                             select a;

                // 利用迴圈逐一讀取每一筆紀錄
                var i = 0;
                str += "現有消費資料種類如下：\n";
                foreach (var record in result)
                {
                    str += string.Format("{0:d2}  ", (i + 1)); // 串接記錄編號(索引值+1)
                    str += string.Format("{0}", record.expenseType);//串接price欄位值(消費金額)
                    str += "\n";
                    i++;
                }

                //
                manageExpenseTypeData.result = str;
                return View(manageExpenseTypeData);
            }
            catch (Exception ex)
            {
                manageExpenseTypeData.result = "取出消費種類時發生例外，原因如下： " + ex.Message;
                return View(manageExpenseTypeData);
            }
        }
        #endregion

        #region 新增酒的種類
        //新增消費種類之局部頁面
        public ActionResult AddNewExpenseType()
        {
            //因此頁面用於載入至開始頁面中，故使用部分檢視回傳
            return PartialView();
        }

        // 新增消費種類資料時的Action
        [HttpPost] //設定此Action只接受頁面POST資料傳入
        //使用Bind的Include來定義只接受的欄位，用來避免傳入其他不相干值
        public ActionResult AddNewExpenseType([Bind(Include = "manageType")] ManageExpenseTypeModel manageExpenseTypeData)
        {
            ExpenseType expenseTypeData = new ExpenseType();
            expenseTypeData.expenseType = manageExpenseTypeData.manageType;

            try
            {
                string str = ""; // 用來儲存結果的字串變數
                // 檢驗擬新增的消費種類是否已存在
                var result = db.types.Where(x => x.expenseType == expenseTypeData.expenseType);
                int count = result.Count(); // 取得記錄數，若count!=0，代表已經存在

                // 若新增的消費種類為null或空白，在結果中加入警示訊息
                if (String.IsNullOrEmpty(expenseTypeData.expenseType))
                {
                    str += "擬新增的消費種類不能為空白，請重新輸入!\n\n";
                }
                else if (count != 0) // 若 count != 0，代表擬新增的消費種類已經存在，在結果中加入警示訊息
                {
                    str += "擬新增的消費種類 " + expenseTypeData.expenseType + " 已經存在，請重新輸入!\n\n";
                }
                else // 若 count == 0，代表擬新增的消費種類還不存在，可存入消費種類資料表中
                {
                    // 如果記錄數為0，表示該新的消費種類不存在，則可將其新增至ExpenseTypes資料表中
                    db.types.Add(expenseTypeData); // 新增消費種類
                    db.SaveChanges();                     // 更新至資料庫
                }

                // 利用LINQ語法取出所有的消費種類紀錄
                var result1 = from a in db.types
                              orderby a.id
                              select a;

                // 利用迴圈逐一讀取每一筆紀錄，並加入編號說明
                var i = 0;
                str += "現有消費資料種類如下：\n";
                foreach (var record in result1)
                {
                    str += string.Format("{0:d2}  ", (i + 1)); // 串接記錄編號(索引值+1)
                    str += string.Format("{0}", record.expenseType);//串接price欄位值(消費金額)
                    str += "\n";
                    i++;
                }

                // 使用TempData的Manage變數攜帶要顯示管理消費種類頁面之新增消費種類結果字串
                TempData["Manage"] = str;

                // 重新導向管理消費種類頁面
                return RedirectToAction("ManageExpenseTypeIndex");
            }
            catch (Exception ex)  // 例外處理
            {
                // 使用TempData的Manage變數攜帶新增消費種類發生例外之原因字串
                TempData["Manage"] = "新增消費種類時發生例外，原因如下: " + ex.Message;

                // 重新導向管理消費種類頁面
                return RedirectToAction("ManageExpenseTypeIndex");
            }
        }
        #endregion

        #region 刪除酒的種類
        //新增留言一開始載入頁面
        public ActionResult DeleteExpenseType()
        {
            //因此頁面用於載入至開始頁面中，故使用部分檢視回傳
            return PartialView();
        }

        //新增留言傳入資料時的Action
        [HttpPost] //設定此Action只接受頁面POST資料傳入
        //使用Bind的Include來定義只接受的欄位，用來避免傳入其他不相干值
        public ActionResult DeleteExpenseType([Bind(Include = "manageTypeNumber")] ManageExpenseTypeModel manageExpenseTypeData)
        {
            try
            {
                string str = "";  // 用於儲存結果之字串變數
                int num = 0;
                // 利用LINQ語法取出所有的消費種類紀錄
                var result = from a in db.types
                             orderby a.id
                             select a;

                int count = result.Count(); // 取出記錄數

                // 若輸入的編號null或空白，在結果中加入警示訊息
                if (String.IsNullOrEmpty(manageExpenseTypeData.manageTypeNumber))
                {
                    str += "擬刪除的消費種類代號不能為空白，請重新輸入!\n\n";
                }
                else
                {
                    num = int.Parse(manageExpenseTypeData.manageTypeNumber);
                    if ((num < 1) || (num > count)) // 輸入的編號不在範圍內，則回傳提示訊息
                    {
                        str += "輸入的編號 " + num + " 需在 1~" + count + " 之間，請重新輸入!\n\n";
                    }
                    else
                    {

                        var record = result.ToArray<ExpenseType>()[num - 1]; //找出指定編號那筆紀錄
                        db.types.Remove(record); // //將指定編號那筆紀錄刪除
                        db.SaveChanges(); // 更新資料庫
                    }
                }

                // 取出最新所有的消費種類
                var result1 = from a in db.types
                              orderby a.id
                              select a;

                // 利用迴圈逐一讀取每一筆紀錄
                var i = 0;
                str += "現有消費資料種類如下：\n";
                foreach (var record1 in result1)
                {
                    str += string.Format("{0:d2}  ", (i + 1)); // 串接記錄編號(索引值+1)
                    str += string.Format("{0}", record1.expenseType);//串接price欄位值(消費金額)
                    str += "\n";
                    i++;
                }
                //
                TempData["Manage"] = str;
                // 重新導向管理消費種類頁面
                return RedirectToAction("ManageExpenseTypeIndex");
            }
            catch (Exception ex)  // 例外處理
            {
                // 使用TempData的Manage變數攜帶刪除消費種類發生例外之原因字串
                TempData["Manage"] = "刪除消費種類時發生例外，原因如下: " + ex.Message;

                // 重新導向管理消費種類頁面
                return RedirectToAction("ManageExpenseTypeIndex");
            }
        }
        #endregion
    }
}