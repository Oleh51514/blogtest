using blogtest.BLL.Interfaces;
using blogtest.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.BLL
{
    public static class BLLCollectionExtentions
    {
        public static IServiceCollection AddBLLServices(
            this IServiceCollection services
        )
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            return services;
        }
    }
}
