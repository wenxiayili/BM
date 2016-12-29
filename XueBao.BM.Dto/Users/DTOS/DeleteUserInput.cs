using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XueBao.BM.Users.DTOS
{
    public class DeleteUserInput
    {
        [Range(1,long.MaxValue)]
        public int UserId { get; set; }
    }
}
