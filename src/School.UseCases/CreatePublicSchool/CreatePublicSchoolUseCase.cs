using FluentValidation;
using School.Application.UseCases.CreatePublicSchool;
using School.Domain.PublicSchools;
using School.Domain.Shared;
using School.Domain.Shared.ValueObjects.Addresses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace School.UseCases.CreatePublicSchool
{
    public class CreatePublicSchoolUseCase : ICreatePublicSchoolUseCase
    {
        private readonly IRepository<PublicSchool> _publicSchoolRepository;

        public CreatePublicSchoolUseCase(IRepository<PublicSchool> publicSchoolRepository)
        {
            _publicSchoolRepository = publicSchoolRepository;
        }

        public async Task Execute(CreatePublicSchoolRequest createPublicSchoolRequest)
        {
            Validate(createPublicSchoolRequest);

            var address = Address.Create(createPublicSchoolRequest.Address.ZipCode, createPublicSchoolRequest.Address.BaseAddress, createPublicSchoolRequest.Address?.ComplementAddress, createPublicSchoolRequest.Address.Neighborhood, createPublicSchoolRequest.Address.City, createPublicSchoolRequest.Address.State);

            var existentPublicSchool = await GetPublicSchoolByInep(createPublicSchoolRequest.Inep);

            if (existentPublicSchool == null)
            {
                var publicSchool = PublicSchool.Create(createPublicSchoolRequest.Inep, createPublicSchoolRequest.Name, address);
                await _publicSchoolRepository.Save(publicSchool);
                return;
            }

            existentPublicSchool.Update(createPublicSchoolRequest.Name, address);
            await _publicSchoolRepository.Save(existentPublicSchool);
        }

        private static void Validate(CreatePublicSchoolRequest createPublicSchoolRequest)
        {
            if (createPublicSchoolRequest == null)
                throw new ArgumentNullException("CreatePublicSchoolRequest");

            var validator = new CreatePublicSchoolRequestValidator();
            validator.ValidateAndThrow(createPublicSchoolRequest);
        }

        private async Task<PublicSchool> GetPublicSchoolByInep(string inep)
        {
            var publicSchools = await _publicSchoolRepository.GetAll();
            return publicSchools?.FirstOrDefault(ps => ps.Inep == inep?.Trim());
        }
    }
}