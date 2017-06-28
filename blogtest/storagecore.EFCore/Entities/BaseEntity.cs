using storagecore.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace storagecore.EFCore.Entities
{
    public class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
