using blogtest.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogtest.MvcApp.Models
{
    public class PostViewModel
    {
        public IEnumerable<Comment> Coments { get; set; }
        public Post Post { get; set; }

    }
}
