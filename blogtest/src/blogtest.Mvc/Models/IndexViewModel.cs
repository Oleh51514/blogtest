using blogtest.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogtest.Mvc.Models
{
    public class IndexViewModel
    {
        public IEnumerable<PostDto> Posts { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
