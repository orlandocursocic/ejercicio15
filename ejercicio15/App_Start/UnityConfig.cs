using ejercicio15.Models;
using ejercicio15.Repository;
using ejercicio15.Servicios;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
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

            // Interceptor de BD
            contenedor.AddNewExtension<Interception>();

            contenedor.RegisterType<IEntradasService, EntradasService>(
            new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<DbInterceptor>());

            contenedor.RegisterType<IEntradasRepository, EntradasRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(contenedor);

        }

        // Interceptor de BD
        public class DbInterceptor : IInterceptionBehavior
        {
            public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
            {
                IMethodReturn result;
                if (ApplicationDbContext.applicationDbContext == null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        ApplicationDbContext.applicationDbContext = context;
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                result = getNext()(input, getNext);

                                if (result.Exception != null)
                                {
                                    throw result.Exception;
                                }
                                context.SaveChanges();

                                dbContextTransaction.Commit();
                            }
                            catch (Exception e)
                            {
                                dbContextTransaction.Rollback();
                                throw new Exception("He hecho rollbak de la transacción", e);
                            }
                        }
                    }
                    ApplicationDbContext.applicationDbContext = null;
                }
                else
                {
                    result = getNext()(input, getNext);


                    if (result.Exception != null)
                    {
                        throw result.Exception;
                    }

                }
                return result;
            }

            public bool WillExecute
            {
                get { return true; }
            }

            public IEnumerable<Type> GetRequiredInterfaces()
            {
                return Type.EmptyTypes;
            }

            private void WriteLog(string message)
            {

            }
        }
    }
}