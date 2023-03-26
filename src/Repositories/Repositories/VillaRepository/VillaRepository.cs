using Business.Repositories.ParentRepository;
using DataAccess.Configuration;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.VillaRepository
{
    internal class VillaRepository : Repository<Villa>, IVillaRepository
    {
        public VillaRepository(ApplicationDbContext dbContext) : base(dbContext) { }


    }
}
