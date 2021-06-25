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
using WEB.Models;


namespace WEB.Controllers
{
    public class DrinkController : Controller
    {

        public async Task<ActionResult> SaveExpenseIndex()
        {
            // 建立一個SaveExpenseViewModel物件
            SaveExpenseModel expenseData = new SaveExpenseModel();

            try
            {
                // 取得消費種類陣列Web API之網址
                string urlGetExpenseTypes = "http://140.137.41.136:1380/A7407630/API/api/WineCupboard";
                //建立HttClient物件
                HttpClient client = new HttpClient();
                // 以非同步GET方式呼叫取得消費種類陣列Web API
                HttpResponseMessage response = await client.GetAsync(urlGetExpenseTypes);
                // 以非同步方式取出回傳結果之JSON格式字串
                string result = await response.Content.ReadAsStringAsync();
                // 將JSON格式字串轉換成.NET的JArray物件 (因為回傳結果為JSON陣列格式字串)
                JArray jsonArray = JArray.Parse(result);
                // 建立一個字串清單物件expenseTypeList
                List<string> expenseTypeList = new List<string>();
                // 將回傳的消費種類一一取出，然後存入字串清單expenseTypeList
                foreach (JObject content in jsonArray.Children<JObject>())
                {
                    expenseTypeList.Add(content.GetValue("expenseType").ToString());
                }
                // 將expenseTypeList存入expenseData物件的expenseTypeList屬性中
                expenseData.expenseTypeList = expenseTypeList;

                // 將expenseData物件傳到View Razor Page
                return View(expenseData);
            }
            catch (Exception ex)
            {
                // 使用TempData的Save變數攜帶儲存消費紀錄發生例外的原因字串
                TempData["Save"] = "儲存消費紀錄時發生例外，原因如下： " + ex.Message;

                // 將expenseTypeList存入expenseData物件的expenseTypeList屬性中
                expenseData.expenseTypeList = new List<string>() { "發生例外!" };

                // 將expenseData物件傳到View Razor Page
                return View(expenseData);
            }
        }

        [HttpPost]
        // 利用Exclude不要自動繫結模型中的result屬性
        public async Task<ActionResult> SaveExpenseIndex([Bind(Exclude = "result")] SaveExpenseModel expenseData)
        {
            try
            {
                // 儲存消費紀錄Web API之網址
                string urlSaveExpense = "http://140.137.41.136:1380/A7407630/API/api/AddDrink/Record";
                //建立HttClient物件
                HttpClient client = new HttpClient();
                // 將expenseData物件序列化成JSON格式字串
                string jsonString = JsonConvert.SerializeObject(expenseData);
                // 建立傳遞內容HttpContent物件，內容格式為application/json
                HttpContent contentPost = new StringContent(jsonString, Encoding.UTF8, "application/json");
                // 以非同步POST方式呼叫儲存消費紀錄Web API
                HttpResponseMessage response = await client.PostAsync(urlSaveExpense, contentPost);
                // 以非同步方式取出回傳結果之JSON格式結果字串
                string result = await response.Content.ReadAsStringAsync();
                // 將JSON格式字串轉換成.NET的JSON物件
                dynamic jsonObject = JsonConvert.DeserializeObject(result);

                // 使用TempData的Save變數攜帶結果字串
                TempData["Save"] = jsonObject.Result;

                //重新導向儲存消費資料頁面
                return RedirectToAction("SaveExpenseIndex");
            }
            catch (Exception ex)  // 例外處理
            {
                // 使用TempData的Result變數攜帶結果字串
                TempData["Save"] = "儲存消費紀錄時發生例外，原因如下: " + ex.Message;

                //重新導向儲存消費資料頁面
                return RedirectToAction("SaveExpenseIndex");
            }
        }

        public ActionResult QueryExpense()
        {
            return View();
        }

        [HttpPost]
        // 利用Exclude不要自動繫結模型中的result屬性
        public async Task<ActionResult> QueryExpense([Bind(Exclude = "result")] QueryExpenseModel queryExpenseData, string btnSend)
        {
            string variety = queryExpenseData.searchType;
            try
            {
                if (btnSend == "查詢酒櫃資料")
                {
                    // 查詢消費紀錄Web API之網址
                    string urlQueryExpense = "http://140.137.41.136:1380/A7407630/API/api/WineCupboard/query/" + variety;
                    //建立HttClient物件
                    HttpClient client = new HttpClient();
                    // 以非同步GET方式呼叫查詢消費紀錄Web API
                    HttpResponseMessage response = await client.GetAsync(urlQueryExpense);
                    // 以非同步方式取出回傳結果之JSON格式字串
                    string result = await response.Content.ReadAsStringAsync();

                    // 將JSON格式字串轉換成.NET的JSON物件
                    dynamic jsonObject = JsonConvert.DeserializeObject(result);

                    // 將查詢消費紀錄頁面之結果字串存入queryExpenseData之result屬性中 
                    queryExpenseData.result = jsonObject.Result;
                }

                //重新導向儲存消費資料頁面
                return View(queryExpenseData);
            }
            catch (Exception ex)  // 例外處理
            {
                // 將查詢消費紀錄發生例外原因字串存入queryExpenseData之result屬性中 
                queryExpenseData.result = "查詢消費紀錄時發生例外，原因如下: " + ex.Message;

                //重新導向儲存消費資料頁面
                return View(queryExpenseData);
            }
        }

        public ActionResult DeleteExpense()
        {
            return View();
        }

        [HttpPost]
        // 利用Exclude不要自動繫結模型中的result屬性
        public async Task<ActionResult> DeleteExpense([Bind(Exclude = "result")] DeleteExpenseModel deleteExpenseData, string btnSend)
        {
            string variety = deleteExpenseData.delType;
            string year = deleteExpenseData.year;
            try
            {
                if (btnSend == "刪除消費資料")
                {
                    // 刪除消費紀錄Web API之網址
                    string urlQueryExpense = "http://140.137.41.136:1380/A7407630/API/api/WineCupboard/delete/" +
                                             variety + "/" + year;
                    //建立HttClient物件
                    HttpClient client = new HttpClient();
                    // 以非同步GET方式呼叫刪除消費紀錄Web API
                    HttpResponseMessage response = await client.GetAsync(urlQueryExpense);
                    // 以非同步方式取出回傳結果之JSON格式字串
                    string result = await response.Content.ReadAsStringAsync();

                    // 將JSON格式字串轉換成.NET的JSON物件
                    dynamic jsonObject = JsonConvert.DeserializeObject(result);

                    // 將查詢消費紀錄頁面之結果字串存入queryExpenseData之result屬性中 
                    deleteExpenseData.result = jsonObject.Result;
                }

                //重新導向儲存消費資料頁面
                return View(deleteExpenseData);
            }
            catch (Exception ex)  // 例外處理
            {
                // 將查詢消費紀錄發生例外原因字串存入queryExpenseData之result屬性中 
                deleteExpenseData.result = "查詢消費紀錄時發生例外，原因如下: " + ex.Message;

                //重新導向儲存消費資料頁面
                return View(deleteExpenseData);
            }
        }

        public async Task<ActionResult> ManageExpenseTypeIndex()
        {
            // 建立一個ManageExpenseTypeViewModel物件
            ManageExpenseTypeModel manageExpenseTypeData = new ManageExpenseTypeModel();

            try
            {
                // 使用GET呼叫Web API
                // 取得所有消費種類格式化字串Web API之網址
                string urlGetAllExpenseTypesString = "http://140.137.41.136:1380/A7407630/API/api/WineCupboard/string/";

                //建立HttClient物件
                HttpClient client = new HttpClient();
                // 以非同步GET呼叫取得所有消費種類格式化字串Web API
                HttpResponseMessage response = await client.GetAsync(urlGetAllExpenseTypesString);
                // 以非同步方式取出回傳結果之JSON格式字串
                string result = await response.Content.ReadAsStringAsync();

                // 將JSON格式字串轉換成.NET的JSON物件
                dynamic jsonObject = JsonConvert.DeserializeObject(result);

                // 使用TempData的Manage變數攜帶要顯示管理消費種類頁面之結果字串
                TempData["Manage"] = jsonObject.Result;

                // 將expenseData物件傳到View Razor Page
                return View(manageExpenseTypeData);
            }
            catch (Exception ex)
            {
                // 使用TempData的Manage變數攜帶管理消費種類發生例外的原因字串
                TempData["Manage"] = "管理消費種類時發生例外，原因如下： " + ex.Message;

                // 將expenseData物件傳到View Razor Page
                return View(manageExpenseTypeData);
            }
        }

        #region 新增消費種類
        //新增消費種類之局部頁面
        public ActionResult AddNewExpenseType()
        {
            //因此頁面用於載入至開始頁面中，故使用部分檢視回傳
            return PartialView();
        }

        // 新增消費種類資料時的Action
        [HttpPost] //設定此Action只接受頁面POST資料傳入
        //使用Bind的Include來定義只接受的欄位，用來避免傳入其他不相干值
        public async Task<ActionResult> AddNewExpenseType([Bind(Include = "expenseType")] ManageExpenseTypeModel manageExpenseTypeData)
        {
            try
            {
                // 新增消費種類Web API之網址
                string urlAddNewExpenseType = "http://140.137.41.136:1380/A7407630/API/api/AddDrink/Type";

                //建立HttClient物件
                HttpClient client = new HttpClient();
                // 將manageExpenseTypeData物件序列化成JSON格式字串
                string jsonString = JsonConvert.SerializeObject(manageExpenseTypeData);
                // 建立傳遞內容HttpContent物件，內容格式為application/json
                HttpContent contentPost = new StringContent(jsonString, Encoding.UTF8, "application/json");
                // 以非同步POST方式呼叫新增消費種類Web API
                HttpResponseMessage response = await client.PostAsync(urlAddNewExpenseType, contentPost);
                // 以非同步方式取出回傳結果之JSON格式字串
                string result = await response.Content.ReadAsStringAsync();

                // 將JSON格式字串轉換成.NET的JSON物件
                dynamic jsonObject = JsonConvert.DeserializeObject(result);

                // 使用TempData的Manage變數攜帶要顯示管理消費種類頁面之新增消費種類結果字串
                TempData["Manage"] = jsonObject.Rresult;

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

        #region 刪除消費種類
        //新增留言一開始載入頁面
        public ActionResult DeleteExpenseType()
        {
            //因此頁面用於載入至開始頁面中，故使用部分檢視回傳
            return PartialView();
        }

        //新增留言傳入資料時的Action
        [HttpPost] //設定此Action只接受頁面POST資料傳入
        //使用Bind的Include來定義只接受的欄位，用來避免傳入其他不相干值
        public async Task<ActionResult> DeleteExpenseType([Bind(Include = "expenseTypeNumber")] ManageExpenseTypeModel manageExpenseTypeData)
        {
            try
            {
                // 刪除消費種類Web API之網址
                string urlAddNewExpenseType = "http://140.137.41.136:1380/A7407630/API/api/WineCupboard/delete/" + manageExpenseTypeData.expenseTypeNumber;

                //建立HttClient物件
                HttpClient client = new HttpClient();
                // 以非同步GET呼叫取得所有消費種類格式化字串Web API
                HttpResponseMessage response = await client.GetAsync(urlAddNewExpenseType);
                // 以非同步方式取出回傳結果之JSON格式字串
                string result = await response.Content.ReadAsStringAsync();

                // 將JSON格式字串轉換成.NET的JSON物件
                dynamic jsonObject = JsonConvert.DeserializeObject(result);

                // 使用TempData的Manage變數攜帶要顯示管理消費種類頁面之刪除消費種類結果字串
                TempData["Manage"] = jsonObject.Result;

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