using FluentValidation;
using SekerTeshis.Entity;
using SekerTeshis.Entity.DTO;

namespace SekerTeshisApp.WebApi.Validation.FluentValidation
{
    public class UserValidator : AbstractValidator<UserDtoForManipulation>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email alani bos gecilemez !.");
            RuleFor(x => x.Password).NotNull().WithMessage("Password alani bos gecilemez !.");
            RuleFor(x => x.UserName).NotNull().WithMessage("UserName alani bos gecilemez !.");
        }
    }
}
