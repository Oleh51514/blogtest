using blogtest.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogtest.Mvc.Models
{
    public class PostViewModel
    {
        public IEnumerable<CommentDto> Coments { get; set; }
        public  PostDto Post { get; set; }
      
    }
}
