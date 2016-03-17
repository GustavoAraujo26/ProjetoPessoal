using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.Cotacao;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Presentation.Controllers.Cotacao
{
    [EnableCors("http://cotacao.gustavodearaujo.com", "*", "*")]
    [RoutePrefix("v1/public")]
    public class RepresentanteController : ApiController
    {
        private readonly IRepresentanteAppService _representanteApp;

        public RepresentanteController(IRepresentanteAppService representanteApp)
        {
            this._representanteApp = representanteApp;
        }

        [HttpGet]
        [Route("representante")]
        public HttpResponseMessage GetRepresentantes()
        {
            try
            {
                var result = _representanteApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram localizados representantes no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar os representantes!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("representante/{id}")]
        public HttpResponseMessage GetRepresentanteById([FromUri] int id)
        {
            try
            {
                var result = _representanteApp.GetById(id);
                if (result == null)
                {
                    var mensagem = "Não foi localizado o representante solicitado!";
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar o representante desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPost]
        [Route("representante")]
        public HttpResponseMessage PostNovoRepresentante([FromBody] Representante representante)
        {
            if (representante == null)
            {
                var mensagem = "Não é possível incluir um novo representante com informações nulas!";
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                _representanteApp.Add(representante);
                var result = representante;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                var location = Url.Link("DefaultApi", new { controller = "representante", id = representante.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = "Houve um erro interno ao incluir um novo representante no banco de dados!";
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("representante/{id}")]
        public HttpResponseMessage PutRepresentante([FromUri] int id, [FromBody] Representante representante)
        {
            if (representante == null)
            {
                var mensagem = string.Format("Não é possível alterar o representante com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                representante.Id = id;
                _representanteApp.Update(representante);
                var result = representante;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o representante desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("representante")]
        public HttpResponseMessage DeleteRepresentante([FromUri] int id)
        {
            try
            {
                var representante = _representanteApp.GetById(id);
                if (representante == null)
                {
                    var mensagem = string.Format("Não foram localizados representantes no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                _representanteApp.Remove(representante);
                return Request.CreateResponse(HttpStatusCode.OK, "Representante excluido com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao excluir o representante desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("representante/lista/{id}")]
        public HttpResponseMessage ListaFornecedoresPorRepresentante([FromUri] int id)
        {
            try
            {
                var result = _representanteApp.ListaFornecedoresPorRepresentante(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram localizados os representantes no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar os representantes desejados!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }
    }
}
