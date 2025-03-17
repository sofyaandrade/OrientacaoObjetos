using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Cidade
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres")]
         public string Nome { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Estado deve ter no mínimo 3 caracteres")]
        public string Estado { get; set; }
    }
}
