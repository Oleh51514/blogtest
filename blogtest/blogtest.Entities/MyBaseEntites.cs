using storagecore.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blogtest.Entities
{
    public abstract class MyBaseEntites<TKey>: BaseEntity<TKey>
    {
        //private String id;

        //[Key]
        //[Required]
        //public String Id
        //{
        //    get {return id ?? (id = Guid.NewGuid().ToString()); }
        //    set { id = value; }
        //}

        [Required]
        public DateTime CreationDate { get; set; }

        protected MyBaseEntites()
        {
            DateTime now = DateTime.Now;
            CreationDate = new DateTime(now.Ticks / 100000 * 100000, now.Kind);
        }
    }
}
