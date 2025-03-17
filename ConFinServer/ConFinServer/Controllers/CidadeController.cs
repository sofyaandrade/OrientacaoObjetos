using ConFinServer.Data;
using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CidadeController(AppDbContext context)
        {
            _context = context;
        }
        
        private static List<Cidade> lista = new List<Cidade>();



        [HttpGet]
        public IActionResult GetCidade()
        {
            try
            {
                var lista = _context.Cidade.OrderBy(e => e.Nome).ToList();
                //select * from estado
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao consultar cidade" + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostCidade(Cidade cidade)
        {
            try
            {
                _context.Cidade.Add(cidade);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir cidade" + ex.Message);
            }

            return Ok("Cidade cadastrada com sucesso");
        }

        [HttpPut]
        public IActionResult PutCidade(Cidade cidade)
        {
            try
            {
                var cidadeExiste =  _context.Cidade.Where(l => l.Codigo == cidade.Codigo).FirstOrDefault();
                if (cidadeExiste!= null)
                {
                    cidadeExiste.Nome = cidade.Nome;
                    _context.Cidade.Update(cidadeExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Cidade não encontrada");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao alterar a cidade" + ex.Message);
            }
            return Ok("Cidade alterada com sucesso!");
        }                                                                                                                                                                                                                                                                        

        [HttpDelete("{codigo}")]
        public IActionResult DeleteCidade([FromBody] Cidade cidade)
        {
            try
            {
                var cidadeExiste = _context.Cidade.Where(l => l.Codigo == cidade.Codigo).FirstOrDefault();
                if (cidadeExiste != null)
                {
                    _context.Cidade.Remove(cidadeExiste);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Cidade não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir cidade" + ex.Message);
            }
            return Ok("Cidade excluido com sucesso");
        }
    }
}
