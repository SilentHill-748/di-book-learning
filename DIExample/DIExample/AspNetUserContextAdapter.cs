using DIExample.Domain;
using DIExample.Domain.Abstractions;

namespace DIExample
{
    public class AspNetUserContextAdapter : IUserContext
    {
        private readonly static HttpContextAccessor Accessor = new();


        public bool IsInRole(Role role)
        {
            if (Accessor.HttpContext is null)
                return false;

            return Accessor.HttpContext.User.IsInRole(role.ToString());
        }
    }
}
