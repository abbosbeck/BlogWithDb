using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

    }
}
