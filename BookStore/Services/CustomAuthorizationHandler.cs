using BookStore.DomainModels.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string UserRole { get; set; }
        public PermissionRequirement(string role)
        {
            UserRole = role;
        }
    }

    public class CustomAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userId = context.User?.FindFirst("UserId")?.Value;
            if (userId == null)
            {
                return Task.CompletedTask;
            }
            else
            {
                if (context.User.Claims.Any(x => x.Value == requirement.UserRole))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    if (context.User.Claims.Any(x => x.Value == UserType.Admin))
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                    context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }
}