using ejercicio15.Repository;
using System.Linq;

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
            return entradasRepository.Create(entrada);

        }

        public void Update(Entrada entrada)
        {

            entradasRepository.Update(entrada);

        }

        public void Delete(long id)
        {

            entradasRepository.Delete(id);

        }

        public Entrada Read(long id)
        {

            return entradasRepository.Read(id);

        }

        public IQueryable<Entrada> ReadAll()
        {

            return entradasRepository.ReadAll();
        }
    }
}