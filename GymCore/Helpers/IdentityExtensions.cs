using Microsoft.AspNet.Identity;
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace GymCore.Helpers
{
    public static class IdentityExtensions
    {
        public static string GetPublicUsername(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }

            if (identity is ClaimsIdentity ci)
            {
                return ci.FindFirstValue("PublicUsername");
            }
            return null;
        }
    }
}