using FrontToBack.DAL;

namespace FrontToBack
{
    public  static class ServiceRegistration
    {
       
        public static void FrontToBackServiceRegistration(this IServiceCollection services)
        {
            services.AddControllersWithViews()
     .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
           
           
        }
    }
}
