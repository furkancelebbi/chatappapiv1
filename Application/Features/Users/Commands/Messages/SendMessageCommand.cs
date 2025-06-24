using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Commands.Messages
{
    public record SendMessageCommand(
        Guid ConversationId,

        string Content) : IRequest<MessageDto>;


}
