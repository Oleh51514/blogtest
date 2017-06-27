using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.Entities.Entities
{
    public class Comment : BaseEntity
    {
        public string TextComment { get; set; }
        public virtual Post Post { get; set; }
    }
}
