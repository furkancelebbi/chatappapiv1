using Application.DTOs;
using Application.Features.Messages.SendMessage;
using Application.Features.Users.Commands.Messages;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace ChatAPI.Application.Features.Messages.Commands.SendMessage;

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, MessageDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserAccessor _userAccessor;
    private readonly IPublisher _publisher;

    public SendMessageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor, IPublisher publisher)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userAccessor = userAccessor;
        _publisher = publisher;
    }

    public async Task<MessageDto> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var senderId = _userAccessor.GetCurrentUserId();

        var conversation = await _unitOfWork.Conversations.GetByIdAsync(request.ConversationId);
        if (conversation == null)
        {
            throw new Exception("Sohbet bulunamadı.");
        }



        var message = new Message
        {
            Content = request.Content,
            ConversationId = request.ConversationId,
            SenderId = senderId,
            SentAt = DateTime.UtcNow
        };

        await _unitOfWork.Messages.AddAsync(message);
        await _unitOfWork.CompleteAsync();

        var createdMessageWithSender = await _unitOfWork.Messages.GetMessageWithSenderAsync(message.Id);
        var messageDto = _mapper.Map<MessageDto>(createdMessageWithSender);


        await _publisher.Publish(new MessageSentNotification(messageDto), cancellationToken);

        return messageDto;
    }
}