using NewsPublish.Model.Entity;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsPublish.Service {

    /// <summary>
    /// Banner 服务
    /// </summary>
    public class BannerService {

        private DB _db;
        public BannerService(DB db) {
            this._db = db;
        }

        /// <summary>
        /// 添加Banner
        /// </summary>
        /// <param name="addBanner"></param>
        /// <returns></returns>
        public ResponseModel AddBanner(Addbanner addBanner) {
            var ba = new Banner {
                AddTime = DateTime.Now,
                Image = addBanner.Image,
                Url = addBanner.Url,
                Remark = addBanner.Remark
            };
            _db.Banner.Add(ba);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "Banner添加成功" };
            return new ResponseModel { code = 0, result = "Banner添加失败" };
        }

        /// <summary>
        /// 获取Banner集合
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetBannerList() {
            var banners = _db.Banner.ToList().OrderByDescending(x => x.AddTime).ToList();
            var response = new ResponseModel();
            response.code = 200;
            response.result = "Banner集合获取成功";
            response.data = new List<BannerModel>();
            foreach (var banner in banners) {
                response.data.Add(new BannerModel {
                    Id = banner.Id,
                    Image = banner.Image,
                    Url = banner.Url,
                    Remark = banner.Remark
                });
            }
            return response;
        }

        /// <summary>
        /// 删除Banner
        /// </summary>
        /// <param name="bannerId"></param>
        /// <returns></returns>
        public ResponseModel DeleteBanner(int bannerId) {
            var banner = _db.Banner.Find(bannerId);
            if (banner == null)
                return new ResponseModel { code = 0, result = "Banner不存在" };
            _db.Banner.Remove(banner);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "Banner删除成功" };
            return new ResponseModel { code = 0, result = "Banner删除失败" };
        }
    }
}
