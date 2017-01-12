using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XueBao.BM.NewsArticles
{
    /// <summary>
    /// 新闻评论 与新闻是多对一的关系
    /// </summary>
    /// 
    [Table("XueBao.NewsComments")]
    public class NewsComments: CreationAuditedEntity
    {
        /// <summary>
        /// 发表评论人
        /// </summary>
        [MaxLength(36)]
        [Required]
        public virtual string Author { get; set; }

        /// <summary>
        /// 评论发表时间
        /// </summary>
        [Required]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [MaxLength(255)]
        [Required]
        public virtual string Content { get; set; }

        /// <summary>
        /// 外键 与News实体之间的对应的关系是1vN
        /// 
        /// </summary>
        public virtual News News { get; set; }


    }
}
