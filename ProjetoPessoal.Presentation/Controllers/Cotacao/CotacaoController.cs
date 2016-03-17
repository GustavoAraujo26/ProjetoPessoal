using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.Cotacao;

namespace ProjetoPessoal.Presentation.Controllers.Cotacao
{
    [EnableCors("http://cotacao.gustavodearaujo.com", "*", "*")]
    [RoutePrefix("v1/public")]
    public class CotacaoController : ApiController
    {
        private readonly ICotacaoAppService _cotacaoApp;

        public CotacaoController(ICotacaoAppService cotacaoApp)
        {
            this._cotacaoApp = cotacaoApp;
        }

        [HttpGet]
        [Route("cotacao")]
        public HttpResponseMessage GetCotacoes()
        {
            try
            {
                var result = _cotacaoApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas cotacoes no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as cotacoes!");
            }
        }

        [HttpGet]
        [Route("cotacao/{id}")]
        public HttpResponseMessage GetCotacaoById([FromUri]int id)
        {
            try
            {
                var result = _cotacaoApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrado a cotacao no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a cotacao {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("cotacao")]
        public HttpResponseMessage PostNovaCotacao([FromBody] Domain.Entities.Cotacao.Cotacao cotacao)
        {
            if (cotacao == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Não é possível incluir uma cotacao em branco!");
            }
            try
            {
                _cotacaoApp.Add(cotacao);
                var result = cotacao;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "cotacao", id = cotacao.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a cotacao desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpPut]
        [Route("cotacao/{id}")]
        public HttpResponseMessage PutCotacao([FromUri] int id, [FromBody] Domain.Entities.Cotacao.Cotacao cotacao)
        {
            if (cotacao == null)
            {
                var mensagem = string.Format("Não é possível alterar a cotacao com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                cotacao.Id = id;
                _cotacaoApp.Update(cotacao);
                var result = cotacao;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a cotacao desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpDelete]
        [Route("cotacao/{id}")]
        public HttpResponseMessage DeleteCotacao([FromUri] int id)
        {
            try
            {
                var cotacao = _cotacaoApp.GetById(id);
                _cotacaoApp.Remove(cotacao);
                return Request.CreateResponse(HttpStatusCode.OK, "cotacao excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a cotacao desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("cotacao/menorpreco")]
        public HttpResponseMessage MenorPreco()
        {
            try
            {
                var result = _cotacaoApp.OfertasPorMenorPreco();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas cotacoes no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as cotacoes!");
            }
        }

        [HttpGet]
        [Route("cotacao/representante/{id}/menorpreco")]
        public HttpResponseMessage OfertasPorRepresentanteEMenorPreco([FromUri] int id)
        {
            try
            {
                var result = _cotacaoApp.OfertasPorRepresentanteEMenorPreco(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas cotacoes no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as cotacoes!");
            }
        }

        [HttpGet]
        [Route("cotacao/produto/{produtoId}/menorpreco")]
        public HttpResponseMessage OfertasPorProdutoEMenorPreco([FromUri] int produtoId)
        {
            try
            {
                var result = _cotacaoApp.OfertasPorProdutoEMenorPreco(produtoId);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas cotacoes no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as cotacoes!");
            }
        }
    }
}
