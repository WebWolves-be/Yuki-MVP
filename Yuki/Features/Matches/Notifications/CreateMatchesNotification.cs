namespace Yuki.Features.Matches.Notifications;

public record CreateMatchesNotification(int CompanyId, int CategoryId) : INotification;