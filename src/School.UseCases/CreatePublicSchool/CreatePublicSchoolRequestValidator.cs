using FluentValidation;
using School.Application.UseCases.CreatePublicSchool;

namespace School.UseCases.CreatePublicSchool
{
    public class CreatePublicSchoolRequestValidator : AbstractValidator<CreatePublicSchoolRequest>
    {
        public CreatePublicSchoolRequestValidator()
        {
            AddNameRules();
            AddAddressRules();
        }

        private void AddNameRules()
        {
            RuleFor(request => request.Name).NotNull();
            RuleFor(request => request.Name).NotEmpty();
        }

        private void AddAddressRules()
        {
            RuleFor(request => request.Address).NotNull();
        }
    }
}
