using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.LivroCaixa;
using ProjetoPessoal.Domain.Entities.LivroCaixa;

namespace ProjetoPessoal.Presentation.Controllers.LivroCaixa
{
    [RoutePrefix("v1/public")]
    public class DebitoCaixaController : ApiController
    {
        private readonly IDebitoCaixaAppService _debitoApp;

        public DebitoCaixaController(IDebitoCaixaAppService debitoApp)
        {
            this._debitoApp = debitoApp;
        }

        [HttpGet]
        [Route("debitocaixa")]
        public HttpResponseMessage GetDebitos()
        {
            try
            {
                var result = _debitoApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontrados debitos no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar os debitos!");
            }
        }

        [HttpGet]
        [Route("debitocaixa/{id}")]
        public HttpResponseMessage GetDebitoById([FromUri]int id)
        {
            try
            {
                var result = _debitoApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrado o debito no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar o debito {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("debitocaixa")]
        public HttpResponseMessage PostNovodebito([FromBody] DebitoCaixa debito)
        {
            if (debito == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Não é possível incluir um debito em branco!");
            }
            try
            {
                _debitoApp.Add(debito);
                var result = debito;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "debitocaixa", id = debito.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir o debito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("debitocaixa/{id}")]
        public HttpResponseMessage Putdebito([FromUri] int id, [FromBody] DebitoCaixa debito)
        {
            if (debito == null)
            {
                var mensagem = string.Format("Não é possível alterar o debito com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                debito.Id = id;
                _debitoApp.Update(debito);
                var result = debito;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o debito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPatch]
        [Route("debitocaixa/{id}")]
        public HttpResponseMessage PatchDebito([FromUri] int id, [FromBody] DebitoCaixa debito)
        {
            if (debito == null)
            {
                var mensagem = string.Format("Não é possível alterar o debito com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                debito.Id = id;
                _debitoApp.Update(debito);
                var result = debito;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o debito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("debitocaixa/{id}")]
        public HttpResponseMessage DeleteDebito([FromUri] int id)
        {
            try
            {
                var item = _debitoApp.GetById(id);
                _debitoApp.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Debito excluido com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir o debito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("debitocaixa/perfil/{perfilId}")]
        public HttpResponseMessage ListaPorPerfil([FromUri] int perfilId)
        {
            try
            {
                var result = _debitoApp.ListaPorPerfil(perfilId);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi localizado nenhum debito com este nome!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao buscar o debito desejado!");
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }
    }
}
