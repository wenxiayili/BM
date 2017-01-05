using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XueBao.BM.Users.DTOS
{
    public class ResetPermissionInput
    {
        [Range(1,long.MaxValue)]
        public int id { get; set; }

        [Required]
        public IEnumerable<string> PermissionName { get; set; }

    }
}
