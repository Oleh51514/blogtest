using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blogtest.Common.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Name field must be filled in")]
        public string NamePost { get; set; }

        [Required(ErrorMessage = "Description field must be filled in")]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
