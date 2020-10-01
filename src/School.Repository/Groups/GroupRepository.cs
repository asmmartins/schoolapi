using School.Domain.Groups;
using School.Domain.Sensores;
using School.Domain.Shared;
using School.Repository.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Repository.Sensores
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly GroupDbContext _context;

        public GroupRepository(GroupDbContext context)
        {
            _context = context;
        }

        public async Task Save(Group aggregation)
        {
            _context.Save(aggregation);
        }


        public async Task<IEnumerable<Group>> GetAll()
        {
            return _context.GetAll();
        }
    }
}