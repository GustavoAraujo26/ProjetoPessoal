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
    public class FazendaController : ApiController
    {
        private readonly IFazendaAppService _fazendaApp;

        public FazendaController(IFazendaAppService fazendaApp)
        {
            this._fazendaApp = fazendaApp;
        }

        [HttpGet]
        [Route("fazenda")]
        public HttpResponseMessage GetFazendas()
        {
            try
            {
                var result = _fazendaApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas fazendas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as fazendas!");
            }
        }

        [HttpGet]
        [Route("fazenda/{id}")]
        public HttpResponseMessage GetFazendaById([FromUri]int id)
        {
            try
            {
                var result = _fazendaApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrada a fazenda no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a fazenda {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("fazenda")]
        public HttpResponseMessage PostNovaFazenda([FromBody] Fazenda fazenda)
        {
            if (fazenda == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível incluir uma fazenda em branco!");
            }
            try
            {
                _fazendaApp.Add(fazenda);
                var result = fazenda;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "fazenda", id = fazenda.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a fazenda desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception);
            }
        }

        [HttpPut]
        [Route("fazenda/{id}")]
        public HttpResponseMessage PutFazenda([FromUri] int id, [FromBody] Fazenda fazenda)
        {
            if (fazenda == null)
            {
                var mensagem = string.Format("Não é possível alterar a fazenda com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                fazenda.Id = id;
                _fazendaApp.Update(fazenda);
                var result = fazenda;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a fazenda desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPatch]
        [Route("fazenda/{id}")]
        public HttpResponseMessage PatchFazenda([FromUri] int id, [FromBody] Fazenda fazenda)
        {
            if (fazenda == null)
            {
                var mensagem = string.Format("Não é possível alterar a fazenda com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                fazenda.Id = id;
                _fazendaApp.Update(fazenda);
                var result = fazenda;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a fazenda desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("fazenda/{id}")]
        public HttpResponseMessage DeleteFazenda([FromUri] int id)
        {
            try
            {
                var fazenda = _fazendaApp.GetById(id);
                _fazendaApp.Remove(fazenda);
                return Request.CreateResponse(HttpStatusCode.OK, "Fazenda excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a fazenda desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("fazenda/produtor/{produtorId}")]
        public HttpResponseMessage FazendasPorProdutor([FromUri]int produtorId)
        {
            try
            {
                var result = _fazendaApp.FazendasPorProdutor(produtorId);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas as fazendas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as fazendas no banco de dados!");
            }
        }
    }
}
