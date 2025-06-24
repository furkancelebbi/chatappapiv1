using FluentValidation;

namespace Application.Features.Users.Commands.Messages
{
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
    {

        public SendMessageCommandValidator()
        {
            RuleFor(x => x.ConversationId)
                .NotEmpty().WithMessage("Sohbet ID'si boş olamaz.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Mesaj içeriği boş olamaz.")
                .MaximumLength(1000).WithMessage("Mesaj en fazla 1000 karakter olabilir.");
        }
    }
}
