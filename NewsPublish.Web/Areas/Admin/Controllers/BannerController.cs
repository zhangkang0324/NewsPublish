using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Service;

namespace NewsPublish.Web.Areas.Admin.Controllers {
    [Area("Admin")]
    public class BannerController : Controller {

        private BannerService _bannerService;
        public BannerController(BannerService bannerService) {
            this._bannerService = bannerService;
        }

        // GET: BannerController
        public ActionResult Index() {
            var banner = _bannerService.GetBannerList();
            return View(banner);
        }

        // GET: BannerController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: BannerController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: BannerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: BannerController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: BannerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: BannerController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: BannerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
