using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shop.DAL.Entities
{
    public class SportInv
    {
        [HiddenInput]
        public int SportInvId { get; set; }

        [Required(ErrorMessage = "Необходимо ввести наименование")]
        [Display(Name = "Наименование")]
        public string SportInvName { get; set; }

        [Required(ErrorMessage = "Необходимо ввести описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле вес заполнено некорректно")]

        [Display(Name = "Вес")]
        [Range(0.001, 200, ErrorMessage = "Введите вес от 0 до 100 кг!")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Необходимо ввести имя группы товаров")]
        [Display(Name = "Группа товаров")]
        public string GroupName { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; }
        [ScaffoldColumn(false)]
        public string MimeType { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Необходимо ввести цену товара")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
