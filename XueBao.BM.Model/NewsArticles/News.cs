using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XueBao.BM.NewsArticles
{
    /// <summary>
    /// 文章
    /// </summary>
    public class News: FullAuditedEntity
    {
        /// <summary>
        /// 文章题目
        /// </summary>
        ///
        [Required]
        [MaxLength(32)]
        public virtual string Title { get; set; }

        /// <summary>
        /// 文章作者
        /// </summary>
        /// 
        [Required]
        [MaxLength(16)]
        public virtual string Author { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>
        /// 
        [Required]
        public virtual DateTime DateTime { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        /// 
        [Required]
        [MaxLength]
        public virtual string Content { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public virtual int Count { get; set; }

        /// <summary>
        /// 与NewsCategory关系是多对1 这个是为了建立与NewsCategory之间的联系
        /// </summary>
        [ForeignKey("NewsCategoryID")]
        public NewsCategory NewsCategory { get; set; }

        public virtual int NewsCategoryID { get; set; }


        ///设置与评论表之间的关系
        ///与评论表之间的关系是 1：N
        public virtual ICollection<NewsComments> NewsComments { get; set; }
    }
}
