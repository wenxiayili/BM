using Abp.Domain.Entities.Auditing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XueBao.BM.NewsArticles
{
    /// <summary>
    /// 新闻分类 与新闻一对多
    /// </summary>
    public class NewsCategory: FullAuditedEntity
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        /// 
        [Required]
        public virtual string Name { get; set; }

        ///设置与News的导航属性
        ///
        [ForeignKey("NewID")]
        public virtual ICollection<News> News { get; set; }
        public virtual int NewID { get; set; }
    }
}
