using FluentValidation;
using School.Application.UseCases.CreateGroup;

namespace School.UseCases.CreateGroup
{
    public class CreateGroupRequestValidator : AbstractValidator<CreateGroupRequest>
    {
        public CreateGroupRequestValidator()
        {
            AddInepRules();
            AddNameRules();            
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
    }
}
