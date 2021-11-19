using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Web_API_ASP.NET_Core.Controllers
{
	[ApiController]
	public abstract class MainController : ControllerBase
	{
		protected ICollection<string> Erros = new List<string>();

		protected ActionResult CustomResponse(ModelStateDictionary modelState)
		{
			var erros = modelState.Values.SelectMany(e => e.Errors);
			foreach (var erro in erros)
			{
				AdicionarErro(erro.ErrorMessage);
			}

			return CustomResponse();
		}

		protected ActionResult CustomResponse(object result = null)
		{
			if (OperacaoValida())
			{
				return Ok(new
				{
					success = true,
					data = result
				});
			}

			return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
			{
				{"Mensagens", Erros.ToArray() }
			}));
		}

		protected void AdicionarErro(string errorMessage)
		{
			Erros.Add(errorMessage);
		}

		private bool OperacaoValida()
		{
			return !Erros.Any();
		}
	}
}