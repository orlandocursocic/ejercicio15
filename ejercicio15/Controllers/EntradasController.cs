using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ejercicio15.Servicios;

namespace ejercicio15.Controllers
{
    public class EntradasController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private IEntradasService entradasService;

        public EntradasController(IEntradasService entradasService) {
            this.entradasService = entradasService;
        }

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return entradasService.ReadAll();
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada entrada = entradasService.Read(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.id)
            {
                return BadRequest();
            }

            try
            {
                entradasService.Update(entrada);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
     
            entrada = entradasService.Create(entrada);

            return CreatedAtRoute("DefaultApi", new { id = entrada.id }, entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada entrada = entradasService.Read(id);
            if (entrada == null)
            {
                return NotFound();
            }

            entradasService.Delete(id);

            return Ok(entrada);
        }
    }
}