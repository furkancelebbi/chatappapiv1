using Application.DTOs;
using MediatR;

namespace Application.Features.Messages.SendMessage;

public record MessageSentNotification(MessageDto Message) : INotification;