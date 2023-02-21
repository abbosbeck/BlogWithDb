using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWithDb.Models
{
    public class PostResponseModel : PostRegisterModel
    {
        public int Id { get; set; }
        public string Date { get; set; }

    }
}
