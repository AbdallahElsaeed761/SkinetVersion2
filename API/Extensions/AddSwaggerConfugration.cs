namespace API.Extensions
{
    public static class AddSwaggerConfugration
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection Services)
        {
            Services.AddSwaggerGen();
            return Services;
        }

        public static IApplicationBuilder AddSwaggerConfigInApp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
