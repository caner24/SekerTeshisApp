using FluentValidation;
using SekerTeshis.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.FluentValidation
{
    public class DiabetDetailForDtoValidator : AbstractValidator<DiabetDetailForDto>
    {
        public DiabetDetailForDtoValidator()
        {
            RuleFor(x => x.MeasureValue).NotNull().NotEmpty().WithMessage(" Şeker sonucunuz boş geçilemez !. ");
            RuleFor(x => x.MeasureType).NotNull().NotEmpty().WithMessage(" Şeker ölçüm tipi boş geçilemez !. ");
        }
    }
}
