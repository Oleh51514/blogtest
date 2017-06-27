using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.Entities.Entities
{
    public class Post : BaseEntity
    {
        public string NamePost { get; set; }
        public string Description { get; set; }

        public List<Comment> Comment { get; set; }
    }
}
