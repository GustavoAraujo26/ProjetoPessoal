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
    public class DespesaGeralController : ApiController
    {
        private readonly IDespesaGeralAppService _despesaGeralApp;

        public DespesaGeralController(IDespesaGeralAppService despesaGeralApp)
        {
            this._despesaGeralApp = despesaGeralApp;
        }

        [HttpGet]
        [Route("despesageral")]
        public HttpResponseMessage GetDespesas()
        {
            try
            {
                var result = _despesaGeralApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas despesas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as despesas!");
            }
        }

        [HttpGet]
        [Route("despesageral/{id}")]
        public HttpResponseMessage GetDespesaById([FromUri]int id)
        {
            try
            {
                var result = _despesaGeralApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrada a despesa no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a despesa {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("despesageral")]
        public HttpResponseMessage PostNovaDespesa([FromBody] DespesaGeral despesaGeral)
        {
            if (despesaGeral == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível incluir uma despesa em branco!");
            }
            try
            {
                _despesaGeralApp.Add(despesaGeral);
                var result = despesaGeral;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "despesageral", id = despesaGeral.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a despesa desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("despesageral/{id}")]
        public HttpResponseMessage PutDespesa([FromUri] int id, [FromBody] DespesaGeral despesaGeral)
        {
            if (despesaGeral == null)
            {
                var mensagem = string.Format("Não é possível alterar a despesa com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                despesaGeral.Id = id;
                _despesaGeralApp.Update(despesaGeral);
                var result = despesaGeral;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a despesa desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("despesageral/{id}")]
        public HttpResponseMessage DeleteCompra([FromUri] int id)
        {
            try
            {
                var despesa = _despesaGeralApp.GetById(id);
                _despesaGeralApp.Remove(despesa);
                return Request.CreateResponse(HttpStatusCode.OK, "Despesa excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a despesa desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("despesageral/balanco/{produtorId}/{ano}")]
        public HttpResponseMessage BalancoDeDespesas([FromUri] int produtorId, [FromUri] int ano)
        {
            try
            {
                var result = _despesaGeralApp.DespesasGeraisPorProdutorEAno(produtorId, ano);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas as despesas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as despesas no banco de dados!");
            }
        }
    }
}
