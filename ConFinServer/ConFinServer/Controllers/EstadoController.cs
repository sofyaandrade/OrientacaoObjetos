using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")] //anotation da rota, vai acessar o ip+porta/api/[nome do controller]
    [ApiController]
    public class EstadoController : ControllerBase //herança da rota
    {
        private readonly AppDbContext _context
            ;

        public EstadoController(AppDbContext context)
        {
            _context = context;
        }

        private static List<Estado> lista = new List<Estado>();

        [HttpGet]
        public IActionResult GetEstado()
        {
            try
            {
                var lista = _context.Estado.OrderBy(e => e.Nome).ToList();
                //select * from estado
                return Ok(lista);
            }
            catch (Exception ex) { 
                return BadRequest("Erro ao consultar estado" + ex.Message);
            }
        }

        /*[HttpGet("Get2")]
        public string GetEstado2()
        {
            var valor = "teste";
            valor = valor + "- BSN 2";
            return valor;
        }*/

        /*[HttpGet("Lista")]
        public List<Estado> GetLista()
        {
            return lista;
        }*/

        [HttpPost]
        public IActionResult PostEstado(Estado estado)
        {
            try
            {
                _context.Estado.Add(estado);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            { 
                return BadRequest("Erro ao incluir estado" + ex.Message);
            }
          
            return Ok("Estado cadastrado com sucesso");
        }

        [HttpPut]
        public IActionResult PutEstado(Estado estado)
        {
            try
            {
                var estadoExiste = _context.Estado.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
                if (estadoExiste != null)
                {
                    estadoExiste.Nome = estado.Nome;
                    _context.Estado.Update(estadoExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Estado não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao alterar o estado" + ex.Message);
            }
            return Ok("Estado alterado com sucesso");
        }

        [HttpDelete]
        public IActionResult DeleteEstado([FromBody] string sigla)
          {
            try
            {
                var estadoExiste = _context.Estado.Where(l => l.Sigla == sigla).FirstOrDefault();
                if (estadoExiste != null)
                {
                    _context.Estado.Remove(estadoExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Estado não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir estado"+ ex.Message);
            }
              return Ok("Estado excluido com sucesso");
          }
    }
}
