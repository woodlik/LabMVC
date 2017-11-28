using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
   public interface IRepository<SportInv>
    {
        IEnumerable<SportInv> GetAllSportInvs();
        SportInv GetSportInv(int SportInvId);
        IEnumerable<SportInv> FindSportInv(Func<SportInv, bool> predicate);
        void CreateSportInv(SportInv SportInv);
        void UpdateSportInv(SportInv SportInv);
        void DeleteSportInv(int SportInvId);
        Task<SportInv> GetSportInvAsync(int SportInvId);
    }
}
