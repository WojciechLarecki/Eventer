using Eventer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventer.API
{
    public static class ServiceHelper
    {
        public static void AddSqlConnection(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EventerContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
