using ejercicio15.Models;
using ejercicio15.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejercicio15.Repository
{
    public class EntradasRepository : IEntradasRepository
    {
        public Entrada Create(Entrada entrada)
        {
            Entrada entradaAux = ApplicationDbContext.applicationDbContext.Entradas.Add(entrada);
            return entradaAux;
        }
    }
}