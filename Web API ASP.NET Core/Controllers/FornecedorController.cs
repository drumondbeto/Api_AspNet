using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_ASP.NET_Core.Controllers
{
    [Route("api/fonecedor")]
    public class FornecedorController : MainController
    {
        [HttpGet]
        public ActionResult ObterFornecedor()
        {
            var fornecedor = new Data.ApplicationDbContext().Fornecedor.ToList();

            if (!fornecedor.Any())
            {
                AdicionarErro("Não há elementos na lista de participantes.");
                return CustomResponse();
            }

            return CustomResponse(fornecedor);
        }
    }
}
