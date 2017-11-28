﻿using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _60322_SPITSYN.Models
{
    public class PageListViewModel<T> : List<T>
    {
        /// <summary>
        /// Общее количество страниц
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int CurrentPage { get; private set; }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="items">список элементов</param>
        /// <param name="total">общее количество страниц</param>
        /// <param name="current">номер текущей страницы</param>
        private PageListViewModel(List<T> items, int total, int current)
        {
            this.AddRange(items);
            TotalPages = total;
            CurrentPage = current;
        }

        /// <summary>
        /// Создание объекта PageListViewModel
        /// </summary>
        /// <param name="items">Полный список объектов</param>
        /// <param name="current">номер текущей страницы</param>
        /// <param name="pageSize">кол. элементов на странице</param>
        /// <returns></returns>
        public static PageListViewModel<T> CreatePage(IEnumerable<T> items, int current, int pageSize)
        {
            var totalCount = items.Count();
            var pagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            var list = items
            .Skip(pageSize * (current - 1))
            .Take(pageSize)
            .ToList();
            //skip - пропускаем размер страницы(3 элемента в данном случае)
            //умноженное на номер страницы - получается, что пропускаем те элементы которые предшествовали  
            //и берем  с помощью Take столько элементо сколько хотим вывести на странице
            return new PageListViewModel<T>(list, pagesCount, current);
        }
    }
}