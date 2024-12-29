using CommentManagement.Application.Comments.Contracts;
using CommentManagement.Application.Users.Contracts;
using CommentManagement.Infrastructure.Repository.Comments;
using CommentManagement.Infrastructure.Repository.DbContexts;
using CommentManagement.Infrastructure.Repository.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Infrastructure.Repository
{
    public static class ServiceRegistrations
    {
        public static void AddRepositories(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services
                .AddDbContext<CommentManagementDbContext>(options => options
                .UseSqlServer(configuration.GetValue<string>("dbConfiguration:connectionString")));
        }
    }
}
