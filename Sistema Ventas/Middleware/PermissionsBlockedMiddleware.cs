using Data.Context;

namespace Sistema_Ventas.Middleware
{
    public class PermissionsBlockedMiddleware
    {
        private readonly RequestDelegate _next;
        public PermissionsBlockedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var db = context.RequestServices.GetRequiredService<ApplicationDbContext>();
            var userIdClaim = context.User?.Claims.FirstOrDefault(u => u.Type == "UserId")?.Value;
            if (int.TryParse(userIdClaim, out var UserId))
            {
                var requestPermission = context.Request.Path.Value;
                var permissionBlocked = db.permissions_blocked.Any(
                    p => p.UserId == UserId && p.Permission == requestPermission);

                if (permissionBlocked)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Blocked access to this resource.");
                    return;
                }

            }
            await _next(context);
        }
    }
}
