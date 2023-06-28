namespace PlaywrightClient.Utilities
{
    public static class OptionsExtension
    {
        public static IServiceCollection BindOptions<TOptions>(this IServiceCollection services, IConfigurationSection configuration) where TOptions : class
        {
            services.AddOptions<TOptions>()
                .Bind(configuration)
                .ValidateDataAnnotations()
                .ValidateOnStart();
            return services;
        }

    }
}
