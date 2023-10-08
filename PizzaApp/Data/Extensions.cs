using System.Runtime.CompilerServices;

namespace PizzaApp.Data
{
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PizzaContext>();

                // 데이터베이스 존재 확인
                context.Database.EnsureCreated();

                DbInitializer.Initialize(context);
            }
        }
    }
}
