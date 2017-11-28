﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ninject;

namespace _60322_SPITSYN.Services
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel krnl)
        {
            kernel = krnl;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}