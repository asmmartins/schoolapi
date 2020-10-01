using School.Domain.PublicSchools;
using System.Collections.Generic;

namespace School.Repository.Shared
{
    public class PublicSchoolDbContext
    {
        private readonly IList<PublicSchool> publicSchools;

        public PublicSchoolDbContext()
        {
            publicSchools = new List<PublicSchool>();
        }

        public void Save(PublicSchool PublicSchool)
        {
            publicSchools.Remove(PublicSchool);
            publicSchools.Add(PublicSchool);
        }

        public IEnumerable<PublicSchool> GetAll() => publicSchools;
    }
}