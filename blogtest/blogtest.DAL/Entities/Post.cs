using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blogtest.DAL.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        public string NamePost { get; set; }
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }

        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
    }
}
