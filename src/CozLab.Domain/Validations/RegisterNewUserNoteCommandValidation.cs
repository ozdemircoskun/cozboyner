using CozLab.Domain.Commands;

namespace CozLab.Domain.Validations
{
    public class RegisterNewUserNoteCommandValidation : UserNoteValidation<RegisterNewUserNoteCommand>
    {
        public RegisterNewUserNoteCommandValidation()
        {
            ValidateDescription();
        }
    }
}