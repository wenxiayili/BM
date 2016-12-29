using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XueBao.BM.Users.DTOS
{
    /// <summary>
    /// 赋予权限;
    /// </summary>
    public class GivePermissionInput
    {
        /// <summary>
        /// user id
        /// </summary>
        [Range(1,long.MaxValue)]
        public int UserId { get; set; }

        /// <summary>
        /// permission name 
        /// </summary>
        [Required]
        public string PerminssionName;
    }
}
