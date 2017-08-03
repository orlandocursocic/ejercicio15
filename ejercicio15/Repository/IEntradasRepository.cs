using System.Collections.Generic;
using System.Linq;

namespace ejercicio15.Repository
{
    public interface IEntradasRepository
    {
        Entrada Create(Entrada entrada);
        Entrada Read(long id);
        IQueryable<Entrada> ReadAll();
        void Delete(long id);
        void Update(Entrada entrada);
    }
}