namespace PokeAPI.Middlewares
{
    public class RedirectMW
    {
        public readonly RequestDelegate request;

        public RedirectMW(RequestDelegate request)
        {
            request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Response.StatusCode == StatusCodes.Status400BadRequest)
            {
                context.Response.Redirect("/error.html");
            }
            await request.Invoke(context);
        }
    }
}
