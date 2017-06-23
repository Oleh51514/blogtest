using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.Common.Dtos
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string TextComment { get; set; }
        public DateTime DateTime { get; set; }
        public int PostId { get; set; }

    }
}
