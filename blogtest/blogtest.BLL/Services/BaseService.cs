using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.BLL.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;

        public BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }

    }
}
