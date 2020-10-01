using FluentValidation;
using School.Application.UseCases.CreatePublicSchool;

namespace School.UseCases.CreatePublicSchool
{
    public class CreatePublicSchoolRequestValidator : AbstractValidator<CreatePublicSchoolRequest>
    {
        public CreatePublicSchoolRequestValidator()
        {
            AddInepRules();
            AddNameRules();
            AddAddressRules();            
        }

        private void AddInepRules()
        {
            RuleFor(request => request.Inep).NotNull();
            RuleFor(request => request.Inep).NotEmpty();
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
