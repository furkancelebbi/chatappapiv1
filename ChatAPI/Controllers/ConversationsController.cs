using Application.DTOs;
using Application.Features.Message.Queries;
using Application.Features.Users.Commands.Messages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ConversationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConversationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{conversationId}/messages")]
    public async Task<ActionResult<MessageDto>> SendMessage(Guid conversationId, SendMessageDto dto)
    {
        var command = new SendMessageCommand(conversationId, dto.Content);
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    [HttpGet("{conversationId}/messages")]
    public async Task<ActionResult<List<MessageDto>>> GetMessagesForConversation(Guid conversationId)
    {
        var query = new GetConversationMessagesQuery(conversationId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}