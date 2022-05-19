namespace DIExample.Domain.Abstractions
{
    public interface IUserContext
    {
        bool IsInRole(Role role);
    }
}
