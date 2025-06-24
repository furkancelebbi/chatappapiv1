using Application.DTOs;
using MediatR;

namespace Application.Features.Message.Queries
{

    public record GetConversationMessagesQuery(Guid ConversationId) : IRequest<List<MessageDto>>;

}
