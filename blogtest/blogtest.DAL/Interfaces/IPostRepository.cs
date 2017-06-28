
using blogtest.Entities.Entities;
using storagecore.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogtest.DAL.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post, string>
    {
        
    }
}
