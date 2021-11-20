using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_ASP.NET_Core.Model;

namespace Web_API_ASP.NET_Core.Controllers
{
    [Route("api/fornecedor")]
    public class FornecedorController : MainController
    {
        [HttpGet]
        public ActionResult ObterFornecedor()
        {
            var fornecedor = new Data.ApplicationDbContext().Fornecedor.ToList();

            if (!fornecedor.Any())
            {
                AdicionarErro("Não há elementos na lista de fornecedores.");
                return CustomResponse();
            }

            return CustomResponse(fornecedor);
        }

        [HttpGet("{id}")]
        public ActionResult ObterFornecedorPorId(Guid id)
        {
            using var db = new Data.ApplicationDbContext();

            var person = db.Fornecedor.Find(id);

            if (person == null)
            {
                AdicionarErro("Id não encontrado.");
                return CustomResponse();
            }
            return CustomResponse(person);
        }

        [HttpPost("new-user")]
        public ActionResult AdicionarFornecedor(Fornecedor fornecedor)
        {
            using var db = new Data.ApplicationDbContext();

            var exist = db.Fornecedor.Where(p => p.Documento == fornecedor.Documento);

            if (exist != null)
            {
                AdicionarErro("Fornecedor já redistrado");
                return CustomResponse();
            }

            db.Fornecedor.Add(fornecedor);
            db.SaveChanges();

            return CustomResponse(fornecedor);
        }

        //[HttpPut("{id}")]
        //public ActionResult AtualizarFornecedor(Guid id)
        //{
            
        //}

        [HttpDelete("{id}/deletar")]
        public ActionResult DeletarFornecedor(Guid id)
        {
            using var db = new Data.ApplicationDbContext();

            var fornecedor = db.Fornecedor.Find(id);

            if (fornecedor == null)
            {
                AdicionarErro("Id não encontrado.");
                return CustomResponse();
                //return NotFound("Id não encontrado");
            }
            db.Entry(fornecedor).State = EntityState.Deleted;
            db.SaveChanges();
            return CustomResponse(fornecedor);
        }
    }
}