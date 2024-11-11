using Data.Context;

namespace Sistema_Ventas.Middleware
{
    public class PermissionsBlockedMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApplicationDbContext _db;
        public PermissionsBlockedMiddleware(RequestDelegate next, ApplicationDbContext db)
        {
            _next = next;
            _db = db;
        }

        public async Task Invoke(HttpContext context)
        {
            var userIdClaim = context.User?.Claims.FirstOrDefault(u => u.Type == "UserId")?.Value;
            if (int.TryParse(userIdClaim, out var UserId))
            {
                var requestPermission = context.Request.Path.Value;
                var permissionBlocked = _db.permissions_blocked.Any(
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
