using FluentValidation;

namespace School.Domain.PublicSchools
{
    public class PublicSchoolValidator : AbstractValidator<PublicSchool>
    {
        public PublicSchoolValidator()
        {
            AddIdRules();
            AddInepRules();
            AddNameRules();
            AdAddressRules();
        }

        private void AddIdRules()
        {
            RuleFor(publicSchool => publicSchool.Id).NotNull();
            RuleFor(publicSchool => publicSchool.Id).NotEmpty();            
        }

        private void AddInepRules()
        {
            RuleFor(publicSchool => publicSchool.Inep).NotNull();
            RuleFor(publicSchool => publicSchool.Inep).NotEmpty();
            RuleFor(publicSchool => publicSchool.Inep).Matches("^[0-9]+$");
            RuleFor(publicSchool => publicSchool.Inep).Length(8, 8);            
        }

        private void AddNameRules()
        {
            RuleFor(publicSchool => publicSchool.Name).NotNull();
            RuleFor(publicSchool => publicSchool.Name).NotEmpty();
            RuleFor(publicSchool => publicSchool.Name).MinimumLength(1);
            RuleFor(publicSchool => publicSchool.Name).MaximumLength(100);
        }

        private void AdAddressRules()
        {
            RuleFor(publicSchool => publicSchool.Address).NotNull();
        }
    }
}