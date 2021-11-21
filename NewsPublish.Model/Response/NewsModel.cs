using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPublish.Model.Response {
    public class NewsModel {
        public int Id { get; set; }
        public int NewsClassifyId { get; set; }
        public string ClassifyName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Contents { get; set; }
        public int CommonCount { get; set; }
        public string Remark { get; set; }
        public string PublishDate { get; set; }
    }
}
