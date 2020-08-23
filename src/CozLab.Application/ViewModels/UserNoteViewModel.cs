using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CozLab.Application.ViewModels
{
    public class UserNoteViewModel
    {

        [Required(ErrorMessage = "Description is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }

    }
}
