using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class FakeRepository : IRepository<SportInv>
    {
        public void CreateSportInv(SportInv SportInv)
        {
            throw new NotImplementedException();
        }

        public void DeleteSportInv(int SportInvId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportInv> FindSportInv(Func<SportInv, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportInv> GetAllSportInvs()
        {           
            return null;
        }

        public SportInv GetSportInv(int SportInvId)
        {
            throw new NotImplementedException();
        }

        public void UpdateSportInv(SportInv SportInv)
        {
            throw new NotImplementedException();
        }

        public Task<SportInv> GetSportInvAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
