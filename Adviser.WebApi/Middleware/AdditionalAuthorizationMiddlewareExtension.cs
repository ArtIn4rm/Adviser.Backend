namespace Adviser.WebApi.Middleware
{
    public static class AdditionalAuthorizationMiddlewareExtension
    {
        public static IApplicationBuilder UseAdditionalAuthorization(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdditionalAuthorizationMiddleware>();
        }
    }
}
