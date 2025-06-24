using Application.DTOs;
using Application.Features.Message.Queries;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace ChatAPI.Application.Features.Messages.Queries.GetConversationMessages;

public class GetConversationMessagesQueryHandler : IRequestHandler<GetConversationMessagesQuery, List<MessageDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserAccessor _userAccessor;

    public GetConversationMessagesQueryHandler(IUnitOfWork unitOfWork, IUserAccessor userAccessor)
    {
        _unitOfWork = unitOfWork;
        _userAccessor = userAccessor;
    }

    public async Task<List<MessageDto>> Handle(GetConversationMessagesQuery request, CancellationToken cancellationToken)
    {
        var userId = _userAccessor.GetCurrentUserId();



        var messagesFromDb = await _unitOfWork.Messages.GetMessagesForConversationAsync(request.ConversationId, 1, 50);

        var messageDtos = new List<MessageDto>();
        foreach (var message in messagesFromDb)
        {
            messageDtos.Add(new MessageDto
            {
                Id = message.Id,
                Content = message.Content,
                SentAt = message.SentAt,
                SenderId = message.SenderId,
                SenderUsername = message.Sender?.Username ?? "Bilinmeyen Kullanıcı",
                ConversationId = message.ConversationId
            });
        }

        return messageDtos;
    }
}