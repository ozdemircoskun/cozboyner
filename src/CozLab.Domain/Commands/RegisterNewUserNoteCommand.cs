using CozLab.Domain.Validations;

namespace CozLab.Domain.Commands
{
    public class RegisterNewUserNoteCommand : UserNoteCommand
    {
        public RegisterNewUserNoteCommand(string description)
        {
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserNoteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}