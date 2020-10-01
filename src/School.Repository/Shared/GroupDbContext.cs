using School.Domain.Groups;
using System.Collections.Generic;

namespace School.Repository.Shared
{
    public class GroupDbContext
    {
        private readonly IList<Group> groups;

        public GroupDbContext()
        {
            groups = new List<Group>();
        }

        public void Save(Group Group) =>
            groups.Add(Group);

        public IEnumerable<Group> GetAll() => groups;
    }
}