using _6MKT.BackOffice.Domain.Labels;
using FluentValidation;

namespace _6MKT.BackOffice.Api.Models.Requests
{
    public class ProviderAddViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SocialNumber { get; set; }
    }

    public class ProviderAddViewModelValidation : AbstractValidator<ProviderAddViewModel>
    {
        public ProviderAddViewModelValidation()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage(string.Format(LabelsBR.ErrorMaximumLength, 100))
                .NotEmpty().WithMessage(LabelsBR.ErrorRequired);

            RuleFor(x => x.LastName)
                .MaximumLength(80).WithMessage(string.Format(LabelsBR.ErrorMaximumLength, 80))
                .NotEmpty().WithMessage(LabelsBR.ErrorRequired);

            RuleFor(x => x.SocialNumber)
                .MaximumLength(20).WithMessage(string.Format(LabelsBR.ErrorMaximumLength, 20))
                .NotEmpty().WithMessage(LabelsBR.ErrorRequired);
        }
    }
}