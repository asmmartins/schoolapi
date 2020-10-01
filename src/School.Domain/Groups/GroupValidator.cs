using FluentValidation;

namespace School.Domain.Groups
{
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            AddIdRules();
            AddNameRules();
        }

        private void AddIdRules()
        {
            RuleFor(group => group.Id).NotNull();
            RuleFor(group => group.Id).NotEmpty();
        }

        private void AddNameRules()
        {
            RuleFor(group => group.Name).NotNull();
            RuleFor(group => group.Name).NotEmpty();
            RuleFor(group => group.Name).MinimumLength(1);
            RuleFor(group => group.Name).MaximumLength(100);
        }
    }
}