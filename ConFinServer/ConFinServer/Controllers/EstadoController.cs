using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")] //anotation da rota, vai acessar o ip+porta/api/[nome do controller]
    [ApiController]
    public class EstadoController : ControllerBase //herança da rota
    {
        private static List<Estado> lista = new List<Estado>();
        
        [HttpGet]
        public string GetEstado()
        {
            var valor = "teste";//f10 linha por linha e f9 pra disparar
            valor = valor + "- BSN";
            return valor;
        }

        [HttpGet("Get2")]
        public string GetEstado2()
        {
            var valor = "teste";
            valor = valor + "- BSN 2";
            return valor;
        }

         [HttpGet("Lista")]
         public List<Estado> GetLista()
         {
             return lista;
         }
        
         [HttpPost]
         public string PostEstado(Estado estado)
         {
             lista.Add(estado);
             return "Estado cadastrado com sucesso";
         }

           [HttpPut]
          public string PutEstado(Estado estado)
          {
              var estadoExiste = lista.Where(l => l.Sigla == estado.Sigla).FirstOrDefault();
              if (estadoExiste != null)
              {
                  estadoExiste.Sigla = estado.Sigla;
                  estadoExiste.Nome = estado.Nome;
              }
              else {
                  return "Estado não encontrado";
              }
              return "Estado alterado com sucesso";
          }
        
          [HttpDelete]
          public string DeleteEstado(string sigla)
          {
              var estadoExiste = lista.Where(l => l.Sigla == sigla).FirstOrDefault();
              if (estadoExiste != null)
              {
                  lista.Remove(estadoExiste);
              }
              else
              {
                  return "Estado não encontrado";
              }
              return "Estado excluido com sucesso";
          }
    }
}
