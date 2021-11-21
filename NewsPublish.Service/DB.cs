using Microsoft.EntityFrameworkCore;
using NewsPublish.Model.Entity;

namespace NewsPublish.Service {

    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class DB : DbContext {
        public DB() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;database=NewsPublic;user=root;password=123456", b => b.UseRelationalNulls());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<NewsClassify> NewsClassify { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }
    }
}
