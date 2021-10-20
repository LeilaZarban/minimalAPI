namespace MinimalApI_net6.Config
{
    public static class WebApplicationExtentions
    {
        public static void AddEndpoints(this WebApplication app)
        {
            var endpoints=app.Services.GetServices<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                endpoint.DefineEndpoints(app);

            }
        }
    }
}
