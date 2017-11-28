using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    class ShopContext: DbContext
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        ///// <param name="name"> имя строки подключения </param>
        public ShopContext(string name) : base(name)
{
            Database.SetInitializer(new ShopContextInitializer());
        }
        public DbSet<SportInv> SportInvs { get; set; }
    }

    class ShopContextInitializer :DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            List<SportInv> SportInvs = new List<SportInv> {
            new SportInv { SportInvId=1,Description="65 % синтетическая кожа, 35 % текстиль",
            SportInvName ="Demix TMJ10BH", GroupName="Бутсы", Weight=0.35,Price=60},

            new SportInv { SportInvId=2,Description="Модель 2015 года",
            SportInvName ="Givova ASS.SCARPA CALCIO THETA SENIOR ASCC12", GroupName="Бутсы", Weight=0.27,Price=80},

            new SportInv { SportInvId=3,Description="Отличный спортивный костюм, который прослужит Вам много лет",
            SportInvName ="Givova TUTA CAMPO TR024", GroupName="Спортивные костюмы", Weight=0.76,Price=85},

            new SportInv { SportInvId=4,Description="Набор маска, трубка и ласты",
            SportInvName ="BECO 99015", GroupName="Трубки, маски, ласты", Weight=2.74,Price=100},

            new SportInv { SportInvId=5,Description="Молот для метания 7.26 кг",
            SportInvName ="Молот для метания", GroupName="Легкая атлетика", Weight=7.26,Price=161},

            new SportInv { SportInvId=6,Description="Мяч для метания 150 грамм",
            SportInvName ="Мяч для метания", GroupName="Легкая атлетика", Weight=0.15,Price=3},

            new SportInv { SportInvId=7,Description="Универсальные лыжи для начинающих спортсменов и любителей активного отдыха",
            SportInvName ="Лыжи беговые универсальные STC", GroupName="Зимний инвентарь", Weight=0.98,Price=51},

            new SportInv { SportInvId=8,Description="Детский сноуборд с облегченными креплениями подойдет для обучения детей катанию по снежным склонам",
            SportInvName ="Сноуборд детский с облегченными креплениями", GroupName="Зимний инвентарь", Weight=0.79,Price=18}
        };
            context.SportInvs.AddRange(SportInvs);
            context.SaveChanges();
        }
    }
}
