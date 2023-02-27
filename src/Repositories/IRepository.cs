using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    internal interface IRepository
    {
        Task Insert(Villa entity);
        Task Delete(Villa entity);
    }
}
