﻿using blogtest.BLL.Interfaces;
using blogtest.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.Bootstrap
{
    public static class BootstrapCollectionExtentions
    {
        public static IServiceCollection AddCoreManagerBootstrap(
            this IServiceCollection services
        )
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            return services;
        }
    }
}
