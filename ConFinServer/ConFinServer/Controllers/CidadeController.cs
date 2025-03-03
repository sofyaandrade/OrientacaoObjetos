using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private static List<Cidade> lista = new List<Cidade>();

        [HttpGet]
        public List<Cidade> GetCidade()
        {
            return lista;
        }

        [HttpPost]
        public string PostCidade([FromBody] Cidade cidade)
        {
            lista.Add(cidade);
            return "Cidade casdastrada com sucesso";
        }

        [HttpPut]
        public string PutCidade([FromBody] Cidade cidade)
        {
            var cidadeExiste =  lista.Where(l => l.Codigo == cidade.Codigo).FirstOrDefault();
            if (cidadeExiste!= null)
            {
                cidadeExiste.Nome = cidade.Nome;
                cidadeExiste.Estado = cidade.Estado;
                return "Cidade alterada com sucesso!";
            }
            else
            {
                return "Cidade não encontrada";
            }
        }

        [HttpDelete("{codigo}")]
        public string DeleteCidade([FromRoute] int codigo)
        {
            var cidadeExiste = lista.Where(l => l.Codigo == codigo).FirstOrDefault();
            if (cidadeExiste != null)
            {
                lista.Remove(cidadeExiste);
                return "Cidade excluida com sucesso";
            }
            else
            {
                return "Cidade não encontrada";
            }
        }
    }
}
