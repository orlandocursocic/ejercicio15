using ejercicio15.Models;
using ejercicio15.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejercicio15.Servicios
{
    public class EntradasService : IEntradasService
    {
        private IEntradasRepository entradasRepository;

        public EntradasService(IEntradasRepository entradasRepository)
        {
            this.entradasRepository = entradasRepository;
        }

        public Entrada Create(Entrada entrada)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entrada = entradasRepository.Create(entrada);

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
                return entrada;
            }
        }


    }
}