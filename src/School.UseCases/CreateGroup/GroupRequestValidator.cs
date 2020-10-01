using FluentValidation;
using School.Application.UseCases.CreateGroup;

namespace School.UseCases.CreateGroup
{
    public class CreateGroupRequestValidator : AbstractValidator<CreateGroupRequest>
    {
        public CreateGroupRequestValidator()
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
            RuleFor(request => request.PublicSchoolId).NotNull();
        }
    }
}
