namespace Quiz_App.Configurations
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
      => applicationBuilder.UseMiddleware<GlobalErrorHandling>();
    }
}

