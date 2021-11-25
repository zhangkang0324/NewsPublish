using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using NewsPublish.Service;

namespace NewsPublish.Web.Areas.Admin.Controllers {

    [Area("Admin")]
    public class NewsController : Controller {

        private NewsService _newsService;
        //private IHostingEnvironment _host;
        public NewsController(NewsService newsService) { // IHostingEnvironment host
            this._newsService = newsService;
            //this._host = host;
        }

        public ActionResult NewsClassify() {
            var classify = _newsService.GetNewsclassifyList();
            return View(classify);
        }

        [HttpPost]
        public JsonResult NewsClassifyAdd(AddNewsClassify newsClassify) {
            if (string.IsNullOrEmpty(newsClassify.Name)) {
                return Json(new ResponseModel { code = 0, result = "请输入新闻类别名称！" });
            }
            return Json(_newsService.AddNewsClassify(newsClassify));
        }
    }
}
