using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.DAL.Interfaces;
using Shop.DAL.Entities;
using System.Collections.Generic;
using _60322_SPITSYN.Controllers;
using System.Web.Mvc;
using _60322_SPITSYN.Models;
using System.Web;
using System.Web.Routing;

namespace _60322_SPITSYN.Tests
{
    [TestClass]
    public class SportInvControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<SportInv>>();
            mock.Setup(r => r.GetAllSportInvs())
                                            .Returns(new List<SportInv> {
                                                                        new SportInv { SportInvId=1 },
                                                                        new SportInv { SportInvId=2 },
                                                                        new SportInv { SportInvId=3 },
                                                                        new SportInv { SportInvId=4 },
                                                                        new SportInv { SportInvId=5 },
                                                                        });
            // Создание объекта контроллера
            var controller = new SportInvController(mock.Object);

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;


            // Act
            // Вызов метода List 
            var view = controller.List(null, 2) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<SportInv> model = view.Model as PageListViewModel<SportInv>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].SportInvId);
            Assert.AreEqual(5, model[1].SportInvId);
        }

        [TestMethod]
        public void CategoryTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<SportInv>>();
            mock.Setup(r => r.GetAllSportInvs())
                                            .Returns(new List<SportInv> {
                                                            new SportInv { SportInvId=1, GroupName="1" },
                                                            new SportInv { SportInvId=2, GroupName="2" },
                                                            new SportInv { SportInvId=3, GroupName="1" },
                                                            new SportInv { SportInvId=4, GroupName="2" },
                                                            new SportInv { SportInvId=5, GroupName="2" },
                                            });
            // Создание объекта контроллера
            var controller = new SportInvController(mock.Object);
            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            // Вызов метода List 
            var view = controller.List("1", 1) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<SportInv> model = view.Model as PageListViewModel<SportInv>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].SportInvId);
            Assert.AreEqual(3, model[1].SportInvId);
        }

        [TestMethod]
        public void DefaultRouteTest()
        {
            // Arrange
            // Макет Http - контекста
            var mockContext = new Mock<HttpContextBase>();
            mockContext
                        .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                        .Returns("~/");
            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act
            //Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }
    }
}
