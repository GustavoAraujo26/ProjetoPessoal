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
    public class PosseController : ApiController
    {
        private readonly IPosseAppService _posseApp;

        public PosseController(IPosseAppService posseApp)
        {
            this._posseApp = posseApp;
        }

        [HttpGet]
        [Route("posse")]
        public HttpResponseMessage GetPosses()
        {
            try
            {
                var result = _posseApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas posses no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as posses!");
            }
        }

        [HttpGet]
        [Route("posse/{id}")]
        public HttpResponseMessage GetPosseById([FromUri]int id)
        {
            try
            {
                var result = _posseApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrada a posse no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a posse {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("posse")]
        public HttpResponseMessage PostNovaPosse([FromBody] Posse posse)
        {
            if (posse == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível incluir uma posse em branco!");
            }
            try
            {
                _posseApp.Add(posse);
                var result = posse;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "posse", id = posse.Id });
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
        [Route("posse/{id}")]
        public HttpResponseMessage PutPosse([FromUri] int id, [FromBody] Posse posse)
        {
            if (posse == null)
            {
                var mensagem = string.Format("Não é possível alterar a posse com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                posse.Id = id;
                _posseApp.Update(posse);
                var result = posse;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a posse desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("posse/{id}")]
        public HttpResponseMessage DeletePosse([FromUri] int id)
        {
            try
            {
                var posse = _posseApp.GetById(id);
                _posseApp.Remove(posse);
                return Request.CreateResponse(HttpStatusCode.OK, "Posse excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a posse desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("posse/balanco/{produtorId}/{ano}")]
        public HttpResponseMessage BalancoDePosses([FromUri] int produtorId, [FromUri] int ano)
        {
            try
            {
                var result = _posseApp.PossesPorProdutorRuralEAno(produtorId, ano);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas as posses no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as posses no banco de dados!");
            }
        }
    }
}
