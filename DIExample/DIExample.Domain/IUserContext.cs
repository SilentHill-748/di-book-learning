namespace DIExample.Domain
{
    public interface IUserContext
    {
        bool IsInRole(Role role);
    }
}
