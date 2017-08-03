using System.Collections.Generic;
using System.Linq;

namespace ejercicio15.Servicios
{
    public interface IEntradasService
    {
        Entrada Create(Entrada entrada);
        void Delete(long id);
        Entrada Read(long id);
        IQueryable<Entrada> ReadAll();
        void Update(Entrada entrada);
    }
}