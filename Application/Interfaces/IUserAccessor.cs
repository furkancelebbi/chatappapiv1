namespace Application.Interfaces;

public interface IUserAccessor
{
    Guid GetCurrentUserId();
}