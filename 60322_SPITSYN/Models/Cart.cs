using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _60322_SPITSYN.Models
{
    public class CartItem
    {
        public SportInv SportInv { get; set; }
        public int quantity { get; set; }
    }


    public class Cart
    {
        List<CartItem> items;
        public Cart()
        {
            items = new List<CartItem>();
        }

        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="SportInv">объект для добавления</param>
        public void AddItem(SportInv SportInv)
        {
            var item = items.Find(i => i.SportInv.SportInvId == SportInv.SportInvId);
            if (item == null)
            {
                items.Add(new CartItem { SportInv = SportInv,quantity = 1 });
            }
            else
                item.quantity += 1;
        }

        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="SportInv">Объект для удаления</param>
        public void RemoveItem(SportInv SportInv)
        {
            var item = items.Find(i => i.SportInv.SportInvId == SportInv.SportInvId);
            if (item.quantity == 1)
                items.Remove(item);
            else
                item.quantity -= 1;
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Получение суммы калорий
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            return items.Sum(i => i.SportInv.Price * i.quantity);
        }

        /// <summary>
        /// Получение содержимого корзины 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return items;
        }
    }
}