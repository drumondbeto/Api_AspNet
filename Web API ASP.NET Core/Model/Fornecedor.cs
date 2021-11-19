using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_ASP.NET_Core.Model
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(3, ErrorMessage = "O campo {0} deve ter entre {1} e {2} caracteres.", MinimumLength = 80)]
        public string Nome { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O campo {0} deve ter entre {1} e {2} caracteres.", MinimumLength = 11)]
        public string Documento { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
