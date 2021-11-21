using NewsPublish.Model.Entity;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NewsPublish.Service {
    public class NewsService {

        private DB _db;
        public NewsService(DB db) {
            this._db = db;
        }

        /// <summary>
        /// 添加新闻类别
        /// </summary>
        /// <param name="newsClassify"></param>
        /// <returns></returns>
        public ResponseModel AddNewsClassify(AddNewsClassify newsClassify) {
            var exit = _db.NewsClassify.FirstOrDefault(c => c.Name == newsClassify.Name) != null;
            if (exit)
                return new ResponseModel { code = 0, result = "该类别已存在" };
            var classify = new NewsClassify { Name = newsClassify.Name, Sort = newsClassify.Sort, Remark = newsClassify.Remark };
            _db.NewsClassify.Add(classify);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻类别添加成功" };
            return new ResponseModel { code = 0, result = "新闻类别添加失败" };
        }

        /// <summary>
        /// 获取一个新闻类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseModel GetOneNewsClassify(int id) {
            var newsClassify = _db.NewsClassify.Find(id);
            if (newsClassify == null)
                return new ResponseModel { code = 0, result = "该类别不存在" };
            return new ResponseModel() {
                code = 200,
                result = "新闻类别获取成功",
                data = new NewsClassify {
                    Id = newsClassify.Id,
                    Name = newsClassify.Name,
                    Sort = newsClassify.Sort,
                    Remark = newsClassify.Remark
                }
            };
        }

        /// <summary>
        /// 获取一个新闻类别
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private NewsClassify GetOneNewsClassify(Expression<Func<NewsClassify, bool>> where) {
            return _db.NewsClassify.FirstOrDefault(where);
        }
        /// <summary>
        /// 编辑新闻类别
        /// </summary>
        /// <param name="newsClassify"></param>
        /// <returns></returns>
        public ResponseModel EditNewsClassify(EditNewsClassify newsClassify) {
            var classify = this.GetOneNewsClassify(c => c.Id == newsClassify.Id);
            if (newsClassify == null)
                return new ResponseModel { code = 0, result = "该类别不存在" };
            classify.Name = newsClassify.Name;
            classify.Sort = newsClassify.Sort;
            classify.Remark = newsClassify.Remark;
            _db.NewsClassify.Update(classify);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻类别编辑成功" };
            return new ResponseModel { code = 0, result = "新闻类别编辑失败" };
        }

        /// <summary>
        /// 获取新闻类型集合
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetNewsclassifyList() {
            var classifyList = _db.NewsClassify.OrderByDescending(x => x.Sort).ToList();
            var response = new ResponseModel { code = 200, result = "新闻类别集合获取成功" };
            response.data = new List<NewClassifyModel>();
            foreach (var classify in classifyList) {
                response.data.Add(new NewClassifyModel {
                    Id = classify.Id,
                    Name = classify.Name,
                    Remark = classify.Remark,
                    Sort = classify.Sort
                });
            }
            return response;
        }
    }
}
