using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listrace.BL.DTOs
{
    public class AppUserLoginDto
    {
        public string UserName { get; set;}
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
