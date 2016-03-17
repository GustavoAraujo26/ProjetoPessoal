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
    public class CreditoCaixaController : ApiController
    {
        private readonly ICreditoCaixaAppService _creditoApp;

        public CreditoCaixaController(ICreditoCaixaAppService creditoApp)
        {
            this._creditoApp = creditoApp;
        }

        [HttpGet]
        [Route("creditocaixa")]
        public HttpResponseMessage GetCreditos()
        {
            try
            {
                var result = _creditoApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontrados creditos no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar os creditos!");
            }
        }

        [HttpGet]
        [Route("creditocaixa/{id}")]
        public HttpResponseMessage GetCreditoById([FromUri]int id)
        {
            try
            {
                var result = _creditoApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrado o credito no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar o credito {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("creditocaixa")]
        public HttpResponseMessage PostNovoCredito([FromBody] CreditoCaixa credito)
        {
            if (credito == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Não é possível incluir um credito em branco!");
            }
            try
            {
                _creditoApp.Add(credito);
                var result = credito;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "creditocaixa", id = credito.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir o credito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("creditocaixa/{id}")]
        public HttpResponseMessage PutCredito([FromUri] int id, [FromBody] CreditoCaixa credito)
        {
            if (credito == null)
            {
                var mensagem = string.Format("Não é possível alterar o credito com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                credito.Id = id;
                _creditoApp.Update(credito);
                var result = credito;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o credito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPatch]
        [Route("creditocaixa/{id}")]
        public HttpResponseMessage PatchCredito([FromUri] int id, [FromBody] CreditoCaixa credito)
        {
            if (credito == null)
            {
                var mensagem = string.Format("Não é possível alterar o credito com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                credito.Id = id;
                _creditoApp.Update(credito);
                var result = credito;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o credito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("creditocaixa/{id}")]
        public HttpResponseMessage DeleteCredito([FromUri] int id)
        {
            try
            {
                var item = _creditoApp.GetById(id);
                _creditoApp.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Credito excluido com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir o credito desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("creditocaixa/perfil/{perfilId}")]
        public HttpResponseMessage ListaPorPerfil([FromUri] int perfilId)
        {
            try
            {
                var result = _creditoApp.ListaPorPerfil(perfilId);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi localizado nenhum credito com este nome!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao buscar o credito desejado!");
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }
    }
}
