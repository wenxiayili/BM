using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace XueBao.BM.Users.DTOS
{
    [AutoMapTo(typeof(User))]
    public class UpdateUserInput
    {
        /// <summary>
        /// user Id
        /// </summary>
        [Range(1,long.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// user password
        /// </summary>
        public string Password { get; set; }
    }
}