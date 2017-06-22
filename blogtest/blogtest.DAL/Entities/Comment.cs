using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.DAL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string TextComment { get; set; }
        public DateTime DateTime { get; set; }

        public int PostId { get; set; }
        public Post Company { get; set; }
    }
}
