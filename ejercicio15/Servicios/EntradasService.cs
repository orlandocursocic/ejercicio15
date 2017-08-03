using ejercicio15.Models;
using ejercicio15.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

        public void Update(Entrada entrada)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entradasRepository.Update(entrada);

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (NoEncontradoException)
                    {
                        dbContextTransaction.Rollback();
                        throw;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
            }
        }

        public void Delete(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entradasRepository.Delete(id);

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
            }
        }

        public Entrada Read(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Entrada entradaAux;

                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entradaAux = entradasRepository.Read(id);

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
                return entradaAux;
            }
        }

        public IQueryable<Entrada> ReadAll()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Entrada> listaEntradas;

                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        listaEntradas = entradasRepository.ReadAll();

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }

                return listaEntradas;
            }
        }


    }
}