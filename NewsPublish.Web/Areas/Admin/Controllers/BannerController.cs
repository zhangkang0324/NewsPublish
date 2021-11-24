using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using NewsPublish.Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System;

namespace NewsPublish.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class BannerController : Controller {

        private BannerService _bannerService;
        private IHostingEnvironment _environment;

        public BannerController(BannerService bannerService, IHostingEnvironment environment) {
            this._bannerService = bannerService;
            this._environment = environment;
        }

        // GET: BannerController
        public ActionResult Index() {
            var banner = _bannerService.GetBannerList();
            return View(banner);
        }

        // GET: BannerController/Details/5
        public ActionResult BannerAdd() {
            return View();
        }

        // GET: BannerController/Create
        [HttpPost]
        public async Task<JsonResult> AddBanner(Addbanner banner, IFormCollection collection) {
            var files = collection.Files;
            if (files.Count > 0) {
                var webRootPath = _environment.WebRootPath;
                string relativeDirPath = "\\BannerPic";
                string absolutePath = webRootPath + relativeDirPath;

                string[] fileTypes = new string[] { ".gif", ".jpg", "jpeg", ".png", ".bmp" };
                string extension = Path.GetExtension(files[0].FileName);
                if (fileTypes.Contains(extension.ToLower())) {
                    if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var filePath = absolutePath + "\\" + fileName;
                    using (var stream = new FileStream(filePath, FileMode.Create)) {
                        await files[0].CopyToAsync(stream);
                    }
                    banner.Image = "/BannerPic/" + fileName;
                    return Json(_bannerService.AddBanner(banner));
                }
                return Json(new ResponseModel { code = 0, result = "图片格式有误" });
            }
            return Json(new ResponseModel { code = 0, result = "请上传图片文件" });
        }

        // POST: BannerController/Create
        [HttpPost]
        public ActionResult DelBanner(int id) {
            if (id <= 0)
                return Json(new ResponseModel { code = 0, result = "参数有误" });
            return Json(_bannerService.DeleteBanner(id));
        }

    }
}
