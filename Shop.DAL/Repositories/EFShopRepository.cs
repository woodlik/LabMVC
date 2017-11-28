using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories
{
    public class EFShopRepository : IRepository<SportInv>
    {
        ShopContext context;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name"> имя строки подключения </param>
        public EFShopRepository(string name)
        {
            context = new ShopContext(name);
        }

        public void CreateSportInv(SportInv t)
        {
            context.SportInvs.Add(t);
            context.SaveChanges();
        }

        public void DeleteSportInv(int id)
        {
            var item = context.SportInvs.Find(id);
            if (item != null)
                context.SportInvs.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<SportInv> FindSportInv(Func<SportInv, bool> predicate)
        {
            return context.SportInvs.Where(predicate).ToList();
        }

        public SportInv GetSportInv(int id)
        {
            return context.SportInvs.Find(id);
        }
        public IEnumerable<SportInv> GetAllSportInvs()
        {
            return context.SportInvs.OrderBy(ap=>ap.SportInvName);
        }

        public void UpdateSportInv(SportInv t)
        {
            context.Entry<SportInv>(t).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Task<SportInv> GetSportInvAsync(int SportInvId)
        {
            return context.SportInvs.FindAsync(SportInvId);
        }
    }
}
