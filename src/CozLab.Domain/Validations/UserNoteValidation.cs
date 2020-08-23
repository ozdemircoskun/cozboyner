using CozLab.Domain.Commands;
using FluentValidation;

namespace CozLab.Domain.Validations
{
    public abstract class UserNoteValidation<T> : AbstractValidator<T> where T : UserNoteCommand
    {
        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

    }
}