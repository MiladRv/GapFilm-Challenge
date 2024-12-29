using Microsoft.Extensions.DependencyInjection;
using CommentManagement.Application.Comments;
using CommentManagement.Application.Comments.Contracts;
using CommentManagement.Application.Users;
using CommentManagement.Application.Users.Contracts;

namespace CommentManagement.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplications(this IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ICommentApplication, CommentApplication>();

        }
    }
}
