using ejercicio15.Models;
using ejercicio15.Servicios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ejercicio15.Repository
{
    public class EntradasRepository : IEntradasRepository
    {
        public Entrada Create(Entrada entrada)
        {
            Entrada entradaAux = ApplicationDbContext.applicationDbContext.Entradas.Add(entrada);
            return entradaAux;
        }

        public void Update(Entrada entrada)
        {
            // Si no existe la entrada en la bd
            if ( !(ApplicationDbContext.applicationDbContext.Entradas.Count(e => e.id == entrada.id) > 0) )
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(entrada).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            Entrada entradaAux = ApplicationDbContext.applicationDbContext.Entradas.Find(id);
            ApplicationDbContext.applicationDbContext.Entradas.Remove(entradaAux);
        }

        public Entrada Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Entradas.Find(id);
        }

        public IQueryable<Entrada> ReadAll()
        {
            IList<Entrada> lista = new List<Entrada>(ApplicationDbContext.applicationDbContext.Entradas);

            return lista.AsQueryable();
        }
    }
}