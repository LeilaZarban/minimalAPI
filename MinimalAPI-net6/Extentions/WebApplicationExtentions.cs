using MinimalAPI_net6.EndPoints;

namespace MinimalAPI_net6.Extentions
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
