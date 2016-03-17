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
    public class ProdutorRuralController : ApiController
    {
        private readonly IProdutorRuralAppService _produtorRuralApp;

        public ProdutorRuralController(IProdutorRuralAppService produtorRuralApp)
        {
            this._produtorRuralApp = produtorRuralApp;
        }
        
        [HttpGet]
        [Route("produtor")]
        public HttpResponseMessage GetProdutores()
        {
            try
            {
                var result = _produtorRuralApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontrados produtores no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    exception);
            }
        }
        
        [HttpGet]
        [Route("produtor/{id}")]
        public HttpResponseMessage GetProdutorById([FromUri]int id)
        {
            try
            {
                var result = _produtorRuralApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrado o produtor no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar o produtor {0} no banco de dados!");
            }
        }
        
        [HttpPost]
        [Route("produtor")]
        public HttpResponseMessage PostNovoProdutor([FromBody] ProdutorRural produtor)
        {
            if (produtor == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível incluir um produtor em branco!");
            }
            try
            {
                _produtorRuralApp.Add(produtor);
                var result = produtor;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "produtorrural", id = produtor.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a posse desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }
        
        [HttpPut]
        [Route("produtor/{id}")]
        public HttpResponseMessage PutProdutor([FromUri] int id, [FromBody] ProdutorRural produtor)
        {
            if (produtor == null)
            {
                var mensagem = string.Format("Não é possível alterar o produtor com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                produtor.Id = id;
                _produtorRuralApp.Update(produtor);
                var result = produtor;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o produtor desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }
        
        [HttpPatch]
        [Route("produtor/{id}")]
        public HttpResponseMessage PatchProdutor([FromUri] int id, [FromBody] ProdutorRural produtor)
        {
            if (produtor == null)
            {
                var mensagem = string.Format("Não é possível alterar o produtor com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                produtor.Id = id;
                _produtorRuralApp.Update(produtor);
                var result = produtor;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o produtor desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }
        
        [HttpDelete]
        [Route("produtor/{id}")]
        public HttpResponseMessage DeleteProdutor([FromUri] int id)
        {
            try
            {
                var prod = _produtorRuralApp.GetById(id);
                _produtorRuralApp.Remove(prod);
                return Request.CreateResponse(HttpStatusCode.OK, "Produtor excluido com sucesso!");
            }
            catch (Exception exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir o produtor desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception);
            }
        }
    }
}
