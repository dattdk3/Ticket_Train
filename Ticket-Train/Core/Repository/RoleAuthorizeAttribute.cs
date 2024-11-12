using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace Ticket_Train.Core.Repository

{
    public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _requiredRole;

        public RoleAuthorizeAttribute(int requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Lấy vai trò từ Session
            var role = context.HttpContext.Session.GetInt32("UserRole");

            // Nếu không có role trong session hoặc role không phù hợp, chặn truy cập
            if (role == null || role ==2)
            {
                // Chuyển hướng đến trang không có quyền truy cập
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
            }
        }
    }
}
