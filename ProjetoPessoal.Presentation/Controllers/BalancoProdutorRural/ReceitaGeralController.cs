using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Presentation.Controllers.BalancoProdutorRural
{
    [EnableCors("http://balanco.gustavodearaujo.com", "*", "*")]
    [RoutePrefix("v1/public")]
    public class ReceitaGeralController : ApiController
    {
        private readonly IReceitaGeralAppService _receitaGeralApp;

        public ReceitaGeralController(IReceitaGeralAppService receitaGeralApp)
        {
            this._receitaGeralApp = receitaGeralApp;
        }

        [HttpGet]
        [Route("receitageral")]
        public HttpResponseMessage GetReceitas()
        {
            try
            {
                var result = _receitaGeralApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas receitas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as receitas!");
            }
        }

        [HttpGet]
        [Route("receitageral/{id}")]
        public HttpResponseMessage GetReceitaById([FromUri]int id)
        {
            try
            {
                var result = _receitaGeralApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrada a receita no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a receita {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("receitageral")]
        public HttpResponseMessage PostNovaReceita([FromBody] ReceitaGeral receitaGeral)
        {
            if (receitaGeral == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível incluir uma receita em branco!");
            }
            try
            {
                _receitaGeralApp.Add(receitaGeral);
                var result = receitaGeral;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "receitaGeral", id = receitaGeral.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a receita desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("receitageral/{id}")]
        public HttpResponseMessage PutReceita([FromUri] int id, [FromBody] ReceitaGeral receitaGeral)
        {
            if (receitaGeral == null)
            {
                var mensagem = string.Format("Não é possível alterar a receita com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                receitaGeral.Id = id;
                _receitaGeralApp.Update(receitaGeral);
                var result = receitaGeral;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a receita desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("receitageral/{id}")]
        public HttpResponseMessage DeleteReceita([FromUri] int id)
        {
            try
            {
                var despesa = _receitaGeralApp.GetById(id);
                _receitaGeralApp.Remove(despesa);
                return Request.CreateResponse(HttpStatusCode.OK, "Receita excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a receita desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("receitageral/balanco/{produtorId}/{ano}")]
        public HttpResponseMessage BalancoDeReceitas([FromUri] int produtorId, [FromUri] int ano)
        {
            try
            {
                var result = _receitaGeralApp.ReceitasGeraisPorProdutorEAno(produtorId, ano);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas as receitas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as receitas no banco de dados!");
            }
        }
    }
}
