using ejercicio15.Repository;
using ejercicio15.Servicios;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.WebApi;

namespace ejercicio15.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var contenedor = new UnityContainer();

            contenedor.RegisterType<IEntradasService, EntradasService>();
            contenedor.RegisterType<IEntradasRepository, EntradasRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(contenedor);

        }
    }
}