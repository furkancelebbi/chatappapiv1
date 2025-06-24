using Application.Features.Messages.SendMessage;
using ChatAPI.WebAPI.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace ChatAPI.ApplicationNotificationHandlers;

public class MessageSentNotificationHandler : INotificationHandler<MessageSentNotification>
{
    private readonly IHubContext<ChatHub> _hubContext;

    public MessageSentNotificationHandler(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Handle(MessageSentNotification notification, CancellationToken cancellationToken)
    {

        await _hubContext.Clients
            .Group(notification.Message.ConversationId.ToString())
            .SendAsync("ReceiveMessage", notification.Message, cancellationToken);
    }
}